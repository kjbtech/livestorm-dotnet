using System.Collections.Generic;
using System.Text.Json.Serialization;
using KJBTech.Livestorm.Common;

namespace KJBTech.Livestorm.Sessions
{
    public class SessionList
    {
        [JsonPropertyName("data")]
        public List<Session> Sessions { get; set; }

        [JsonPropertyName("meta")]
        public PaginationData PaginationData { get; set; }
    }
}
