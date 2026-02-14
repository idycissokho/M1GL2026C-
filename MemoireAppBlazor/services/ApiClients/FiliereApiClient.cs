using MemoireAppBlazor.DTOs;
using System.Net.Http.Json;

namespace MemoireAppBlazor.Services.ApiClients
{
    public class FiliereApiClient
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "api/Filieres";

        public FiliereApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<FiliereDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<FiliereDto>>(BaseUrl) ?? new();
        }

        public async Task<FiliereDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<FiliereDto>($"{BaseUrl}/{id}");
        }

        public async Task<FiliereDto> CreateAsync(CreateFiliereDto dto)
        {
            var response = await _http.PostAsJsonAsync(BaseUrl, dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FiliereDto>() ?? throw new Exception("Failed to create");
        }

        public async Task<bool> UpdateAsync(int id, UpdateFiliereDto dto)
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
