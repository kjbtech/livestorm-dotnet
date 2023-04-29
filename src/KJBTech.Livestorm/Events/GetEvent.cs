using System.Text.Json.Serialization;

namespace KJBTech.Livestorm.Events
{
    public class GetEvent
    {
        [JsonPropertyName("data")]
        public Event Event { get; set; }
    }
}
