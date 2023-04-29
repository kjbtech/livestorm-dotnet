using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;

namespace KJBTech.Livestorm
{
    public partial class LivestormApi
    {
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.Livestorm.co/v1";
        private readonly RestClient _httpClient;
        private readonly ILogger _logger;

        public LivestormApi(
            ILogger<LivestormApi> logger
            , IOptions<LivestormSettings> LivestormSettings)
        {
            _logger = logger;
            _apiKey = LivestormSettings.Value.ApiKey;
            _httpClient = BuildClient();
        }

        public async Task<bool> PingAsync()
        {
            var request = new RestRequest("ping", Method.Get);
            var response = await _httpClient.ExecuteAsync(request);

            return response.StatusCode == HttpStatusCode.OK;
        }

        private RestClient BuildClient()
        {
            var options = new RestClientOptions(BaseUrl);
            var client = new RestClient(options,
                p => p.Add("Authorization", _apiKey)
            );

            client.AddDefaultHeader("User-Agent", BuildUserAgent());

            return client;
        }

        // Livestorm limits API request to 10 000 a month and 5 a second, by default.
        // If one of this limit is reached, a 429 code is received.
        // This method is a circuit breaker to handle this.
        private async Task<RestResponse> ProcessRequestAsync(RestRequest request, int tryCount = 0)
        {
            RestResponse response;
            try
            {
                response = await _httpClient.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new LivestormException("An unexpected error occured when requesting Livestorm API.", ex);
            }

            var rateLimitRemainingHeader = response.Headers?.FirstOrDefault(h => h.Name?.ToLower() == "ratelimit-montly-remaining");
            if (rateLimitRemainingHeader != null
                && int.TryParse(rateLimitRemainingHeader?.Value?.ToString(), out int rateLimitRemaining)
                && rateLimitRemaining < 1000)
            {
                _logger.LogError("Caution: least than 1000 request in the current month.");
            }

            if (response.IsSuccessful)
            {
                return response;
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.TooManyRequests:

                    _ = int.TryParse(
                            response.Headers?.First(h => h.Name?.ToLower() == "retry-after")?.Value?.ToString(),
                            out int retryAfter);

                    // monthly rate limit reached so we throw an exception.
                    if (rateLimitRemainingHeader != null
                        && int.TryParse(
                            rateLimitRemainingHeader?.Value?.ToString(),
                            out rateLimitRemaining)
                        && rateLimitRemaining <= 0
                        && int.TryParse(
                            response.Headers?.First(h => h.Name?.ToLower() == "ratelimit-montly-limit")?.Value?.ToString(),
                            out int rateLimit))
                    {
                        string message = $"La limite mensuelle de requêtes API Livestorm a été atteinte (limite = {rateLimit}). Contacter d'urgence le support Livestorm.";
                        _logger.LogCritical(message);

                        throw new LivestormException(message);
                    }

                    // second rate limit reached so we wait the amount of seconds that Livestorm send us before re-execute.
                    // we stop when we exceed 3 try.
                    if (tryCount >= 2)
                    {
                        throw new LivestormException($"Too many requests, try later.");
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(retryAfter));
                    tryCount++;
                    await ProcessRequestAsync(request, tryCount);
                    break;

                default:
                    throw new LivestormException($"Request was not successfull for the following reasons: Code:{response.StatusCode} Content: '{response.Content}'");
            }

            return response;
        }

        private async Task<T> ProcessRequestAsync<T>(RestRequest request)
            where T : class, new()
        {
            var response = await ProcessRequestAsync(request);

            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                return JsonSerializer.Deserialize<T>(response.Content) ?? new T();
            }

            _logger.LogWarning("The content of the response was null or empty.");

            return new T();
        }

        private string BuildUserAgent()
        {
            return $"livestorm-dotnet@v{Assembly.GetExecutingAssembly().GetName().Version}"
                + $" dotnet-v{Environment.Version}"
                + $" {Environment.OSVersion}";
        }
    }
}
