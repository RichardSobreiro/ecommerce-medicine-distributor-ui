using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Text.Json.Serialization;

namespace EcommerceMedDistUI.Authentication
{
    public class CustomOidcOptions : OidcProviderOptions
    {
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }
    }
}
