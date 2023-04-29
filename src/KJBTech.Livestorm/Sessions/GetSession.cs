using System.Text.Json.Serialization;
using KJBTech.Livestorm.Sessions;

namespace KJBTech.Livestorm
{
    public class GetSession
    {
        [JsonPropertyName("data")]
        public Session Session { get; set; }
    }
}
