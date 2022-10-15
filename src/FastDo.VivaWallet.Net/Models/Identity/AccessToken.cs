﻿using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Identity
{
    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string? Token { get; set; }
       
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }
    }
}
