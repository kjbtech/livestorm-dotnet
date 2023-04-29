using System;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KJBTech.Livestorm.Common;
using KJBTech.Livestorm.People;
using RestSharp;

namespace KJBTech.Livestorm
{
    public partial class LivestormApi
    {
        public async Task<Registrant?> GetSpeakerAsync(Guid sessionId)
        {
            int pageNumber = 0;
            string baseQuery = $"sessions/{sessionId}/people";

            Registrant? speaker;
            RegistrantList registrantList;

            do
            {
                var query = baseQuery + $"?page[number]={pageNumber}&page[size]={50}";
                var request = new RestRequest(query, Method.Get);

                registrantList = await ProcessRequestAsync<RegistrantList>(request);

                speaker = registrantList
                    .Registrants?
                    .FirstOrDefault(r => r.Attributes.RegistrantDetails.IsGuestSpeaker && r.Attributes.RegistrantDetails.IsHighlighted);

                pageNumber++;
            }
            while (speaker is null
                    && registrantList.PaginationData.PageCount > pageNumber);

            return speaker;
        }

        public async Task<Registrant?> GetRegisteredUserAsync(Guid lsSessionId, PersonQuery personQuery)
        {
            RegistrantList registrantList;

            RestRequest request = new RestRequest($"sessions/{lsSessionId}/people?filter[email]={personQuery.Email}", Method.Get);

            registrantList = await ProcessRequestAsync<RegistrantList>(request);

            return registrantList.Registrants?.FirstOrDefault();
        }

        public async Task<GetRegistrant> RegisterUserAsync(Guid lsSessionId, Person person)
        {
            var lastName = new { id = "last_name", value = person.Attributes.LastName };
            var firstName = new { id = "first_name", value = person.Attributes.FirstName };
            var email = new { id = "email", value = person.Attributes.Email };

            dynamic creationDto = new ExpandoObject();
            creationDto.data = new ExpandoObject();
            creationDto.data.type = "people";
            creationDto.data.attributes = new ExpandoObject();
            creationDto.data.attributes.fields = new[] { lastName, firstName, email };

            string body = JsonSerializer.Serialize(creationDto);

            RestRequest request = new RestRequest($"sessions/{lsSessionId}/people", Method.Post);
            request.AddParameter("application/vnd.api+json", body, ParameterType.RequestBody);

            return await ProcessRequestAsync<GetRegistrant>(request);
        }
    }
}
