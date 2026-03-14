using System.Net.Http.Json;

namespace MemoireAppBlazor.Services.ApiClients
{
    public class AuthApiClient
    {
        private readonly HttpClient _http;

        public AuthApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", new { email, password });
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            return result?.Token;
        }
    }

    public class TokenResponse
    {
        public string Token { get; set; } = "";
    }
}
