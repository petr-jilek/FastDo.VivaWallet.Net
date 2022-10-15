using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Payments
{
    public class CreatePaymentOrderResponse
    {
        [JsonPropertyName("orderCode")]
        public long OrderCode { get; set; }
    }
}
