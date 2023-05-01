using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace KJBTech.Livestorm.IntegrationTests
{
    [Trait("Category", "Livestorm API V1")]
    public class LivestormApiUnitTests
    {
        protected LivestormApi _api;

        public LivestormApiUnitTests()
        {
            _api = GetLivestormApi();
        }

        [Fact]
        public async Task Ping_Success()
        {
            var result = await _api.PingAsync();

            Assert.True(result);
        }

        private LivestormApi GetLivestormApi()
        {
            var apiKey = Environment.GetEnvironmentVariable("Livestorm__ApiKey");

            return new LivestormApi(
                new Logger<LivestormApi>(new NullLoggerFactory())
                , Options.Create(new LivestormSettings()
                {
                    ApiKey = apiKey
                }));
        }
    }
}
