using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Common
{
    public class Customer
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; } = null;

        [JsonPropertyName("fullName")]
        public string? FullName { get; set; } = null;

        [JsonPropertyName("phone")]
        public string? Phone { get; set; } = null;

        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; } = null;

        [JsonPropertyName("requestLang")]
        public string? RequestLang { get; set; } = null;
    }
}
