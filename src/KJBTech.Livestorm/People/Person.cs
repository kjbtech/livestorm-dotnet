using System.Text.Json.Serialization;
using KJBTech.Livestorm.Common;

namespace KJBTech.Livestorm
{
    public sealed class Person : LivestormObject<PeopleAttributes>
    {
    }

    public class PeopleAttributes
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("avatar_link")]
        public string AvatarLink { get; set; }
    }
}
