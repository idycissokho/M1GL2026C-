using MemoireAppBlazor.DTOs;
using System.Net.Http.Json;

namespace MemoireAppBlazor.Services.ApiClients
{
    public class EtudiantApiClient
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "api/Etudiants";

        public EtudiantApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EtudiantDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<EtudiantDto>>(BaseUrl) ?? new();
        }

        public async Task<EtudiantDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<EtudiantDto>($"{BaseUrl}/{id}");
        }

        public async Task<EtudiantDto> CreateAsync(CreateEtudiantDto dto)
        {
            var response = await _http.PostAsJsonAsync(BaseUrl, dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<EtudiantDto>() ?? throw new Exception("Failed to create");
        }

        public async Task<bool> UpdateAsync(int id, UpdateEtudiantDto dto)
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
