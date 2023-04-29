using System.Text.Json.Serialization;

namespace KJBTech.Livestorm.Common
{
    /// <summary>
    /// Pagination data
    /// Got from all endpoint under the key name "meta".
    /// </summary>
    public sealed class PaginationData
    {
        [JsonPropertyName("next_page")]
        public int? NextPage { get; set; }

        [JsonPropertyName("record_count")]
        public int RecordCount { get; set; } = 0;

        [JsonPropertyName("page_count")]
        public int PageCount { get; set; } = 0;
    }
}
