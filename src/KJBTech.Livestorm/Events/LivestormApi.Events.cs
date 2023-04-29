using System;
using System.Threading.Tasks;
using KJBTech.Livestorm.Events;
using RestSharp;

namespace KJBTech.Livestorm
{
    public partial class LivestormApi
    {
        public async Task<GetEvent> GetEventAsync(Guid eventId)
        {
            var request = new RestRequest($"events/{eventId}", Method.Get);

            var @event = await ProcessRequestAsync<GetEvent>(request);

            return @event;
        }
    }
}
