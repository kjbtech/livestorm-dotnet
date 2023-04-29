using System;
using System.Text.Json.Serialization;
using KJBTech.Livestorm.Common;

namespace KJBTech.Livestorm.Sessions
{
    public sealed class Session : LivestormObject<SessionAttributes>
    {
    }

    public sealed class SessionAttributes
    {
        [JsonPropertyName("event_id")]
        public Guid EventId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("room_link")]
        public string RoomLink { get; set; }

        [JsonPropertyName("attendees_count")]
        public int AttendeesCount { get; set; }

        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        [JsonPropertyName("estimated_started_at")]
        public long EstimatedStartedAt { get; set; }

        [JsonPropertyName("started_at")]
        public long StartedAt { get; set; }

        [JsonPropertyName("ended_at")]
        public long EndedAt { get; set; }

        [JsonPropertyName("canceled_at")]
        public long CanceledAt { get; set; }

        [JsonPropertyName("create_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("registrants_count")]
        public int RegistrantsCount { get; set; }
    }
}
