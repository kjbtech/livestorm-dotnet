using System.Text.Json.Serialization;

namespace KJBTech.Livestorm.Common
{
    public class Field
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}
