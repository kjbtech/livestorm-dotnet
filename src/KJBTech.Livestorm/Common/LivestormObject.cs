using System;
using System.Text.Json.Serialization;

namespace KJBTech.Livestorm.Common
{
    public abstract class LivestormObject
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        internal string Type { get; set; }
    }

    public abstract class LivestormObject<TAttributes> : LivestormObject where TAttributes : class
    {
        [JsonPropertyName("attributes")]
        public TAttributes Attributes { get; set; }
    }
}
