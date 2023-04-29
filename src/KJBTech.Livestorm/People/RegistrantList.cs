using System.Collections.Generic;
using System.Text.Json.Serialization;
using KJBTech.Livestorm.Common;

namespace KJBTech.Livestorm.People
{
    public sealed class RegistrantList
    {
        [JsonPropertyName("data")]
        public List<Registrant> Registrants { get; set; }

        [JsonPropertyName("meta")]
        public PaginationData PaginationData { get; set; }
    }
}
