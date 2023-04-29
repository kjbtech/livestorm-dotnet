using System.Text.Json.Serialization;

namespace KJBTech.Livestorm.People
{
    public class GetRegistrant
    {
        [JsonPropertyName("data")]
        public Registrant Registrant { get; set; }
    }
}
