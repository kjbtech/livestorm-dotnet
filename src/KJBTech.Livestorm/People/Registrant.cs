using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using KJBTech.Livestorm.Common;

namespace KJBTech.Livestorm.People
{
    public sealed class Registrant : LivestormObject<RegistrantAttributes>
    {
    }

    public sealed class RegistrantAttributes : PeopleAttributes
    {
        #region Properties

        [JsonPropertyName("registrant_detail")]
        public RegistrantDetail RegistrantDetails { get; set; }

        [JsonPropertyName("messages_count")]
        public int MessagesCount { get; set; }

        [JsonPropertyName("questions_count")]
        public int QuestionsCount { get; set; }

        [JsonPropertyName("votes_count")]
        public int VotesCount { get; set; }

        [JsonPropertyName("up_votes_count")]
        public int UpVotesCount { get; set; }

        #endregion Properties
    }

    public class RegistrantDetail
    {
        #region Properties

        [JsonPropertyName("event_id")]
        public Guid EventId { get; set; }

        [JsonPropertyName("session_id")]
        public Guid SessionId { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("fields")]
        public ICollection<Field> Fields { get; set; }

        [JsonPropertyName("referrer")]
        public string Referrer { get; set; }

        [JsonPropertyName("utm_source")]
        public string UtmSource { get; set; }

        [JsonPropertyName("utm_medium")]
        public string UtmMedium { get; set; }

        [JsonPropertyName("utm_term")]
        public string UtmTerm { get; set; }

        [JsonPropertyName("utm_content")]
        public string UtmContent { get; set; }

        [JsonPropertyName("utm_campaign")]
        public string UtmCampaign { get; set; }

        [JsonPropertyName("browser_name")]
        public string BrowserName { get; set; }

        [JsonPropertyName("browser_version")]
        public string BrowserVersion { get; set; }

        [JsonPropertyName("os_name")]
        public string OSName { get; set; }

        [JsonPropertyName("os_version")]
        public string OSVersion { get; set; }

        [JsonPropertyName("screen_height")]
        public string ScreenHeight { get; set; }

        [JsonPropertyName("screen_width")]
        public string ScreenWidth { get; set; }

        [JsonPropertyName("ip_city")]
        public string IPCity { get; set; }

        [JsonPropertyName("ip_country_code")]
        public string IPCountryCode { get; set; }

        [JsonPropertyName("ip_country_name")]
        public string IPCountryName { get; set; }

        [JsonPropertyName("password_key")]
        public string PasswordKey { get; set; }

        [JsonPropertyName("connection_link")]
        public string ConnectionLink { get; set; }

        [JsonPropertyName("attended")]
        public bool Attended { get; set; }

        [JsonPropertyName("attendance_rate")]
        public string AttendanceRate { get; set; }

        [JsonPropertyName("attendance_duration")]
        public double AttendanceDuration { get; set; }

        [JsonPropertyName("is_highlighted")]
        public bool IsHighlighted { get; set; }

        [JsonPropertyName("is_guest_speaker")]
        public bool IsGuestSpeaker { get; set; }

        #endregion Properties
    }
}
