using System.Text.Json.Serialization;
using KJBTech.Livestorm.Common;

namespace KJBTech.Livestorm.Events
{
    public sealed class Event : LivestormObject<EventAttributes>
    {
    }

    public sealed class EventAttributes
    {
        #region Properties

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("registration_link")]
        public string RegistrationLink { get; set; }

        [JsonPropertyName("estimated_duration")]
        public int EstimatedDuration { get; set; }

        [JsonPropertyName("registration_page_enabled")]
        public bool RegistrationPageEnabled { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("published_at")]
        public long PublishedAt { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("sessions_count")]
        public int SessionsCount { get; set; }

        [JsonPropertyName("owner")]
        public Person Owner { get; set; }

        #endregion Properties
    }
}
