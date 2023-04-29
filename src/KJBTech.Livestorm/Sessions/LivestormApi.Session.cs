using System.Collections.Generic;
using System.Threading.Tasks;
using KJBTech.Livestorm.Sessions;
using RestSharp;

namespace KJBTech.Livestorm
{
    public partial class LivestormApi
    {
        public async Task<IEnumerable<Session>> ListUpcomingSessionsAsync()
        {
            int pageNumber = 0, pageSize = 50;
            string baseQuery = $"sessions?filter[status]=upcoming";

            var conferences = new List<Session>();
            SessionList sessionList;

            do
            {
                var query = baseQuery + $"&page[number]={pageNumber}&page[size]={pageSize}";
                var request = new RestRequest(query, Method.Get);

                sessionList = await ProcessRequestAsync<SessionList>(request);

                conferences.AddRange(sessionList.Sessions);
                pageNumber = sessionList.PaginationData.NextPage ?? 0;
            } while (sessionList.PaginationData.NextPage != null);

            return conferences;
        }

        public async Task<IEnumerable<Session>> ListOnDemandSessionsAsync()
        {
            int pageNumber = 0, pageSize = 50;
            string baseQuery = $"sessions?filter[status]=on_demand";

            var conferences = new List<Session>();
            SessionList sessionList;

            do
            {
                var query = baseQuery + $"&page[number]={pageNumber}&page[size]={pageSize}";
                var request = new RestRequest(query, Method.Get);

                sessionList = await ProcessRequestAsync<SessionList>(request);

                conferences.AddRange(sessionList.Sessions);
                pageNumber = sessionList.PaginationData.NextPage ?? 0;
            } while (sessionList.PaginationData.NextPage != null);

            return conferences;
        }

        public async Task<SessionList> ListOnDemandSessionsAsync(PaginationParameter paginationParameter)
        {
            string baseQuery = $"sessions?filter[status]=on_demand";

            var query = baseQuery + $"&page[number]={paginationParameter.PageNumber}&page[size]={paginationParameter.PageSize}";
            var request = new RestRequest(query, Method.Get);

            return await ProcessRequestAsync<SessionList>(request);
        }

        public async Task<GetSession> GetSessionAsync(string sessionId)
        {
            string baseQuery = $"sessions";

            var query = baseQuery + $"/{sessionId}";
            var request = new RestRequest(query, Method.Get);

            return await ProcessRequestAsync<GetSession>(request);
        }
    }
}
