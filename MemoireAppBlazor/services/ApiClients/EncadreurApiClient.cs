using MemoireAppBlazor.DTOs;
using System.Net.Http.Json;

namespace MemoireAppBlazor.Services.ApiClients
{
    public class EncadreurApiClient
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "api/Encadreurs";

        public EncadreurApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EncadreurDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<EncadreurDto>>(BaseUrl) ?? new();
        }

        public async Task<EncadreurDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<EncadreurDto>($"{BaseUrl}/{id}");
        }

        public async Task<EncadreurDto> CreateAsync(CreateEncadreurDto dto)
        {
            var response = await _http.PostAsJsonAsync(BaseUrl, dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<EncadreurDto>() ?? throw new Exception("Failed to create");
        }

        public async Task<bool> UpdateAsync(int id, UpdateEncadreurDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
