using MemoireAppBlazor.DTOs;
using MemoireAppBlazor.Services.Interfaces;
using System.Net.Http.Json;

namespace MemoireAppBlazor.Services.ApiClients
{
    public class MemoireApiClient : IApiClient<MemoireDto, CreateMemoireDto>
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "api/Memoires";

        public MemoireApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MemoireDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<MemoireDto>>(BaseUrl) ?? new();
        }

        public async Task<MemoireDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<MemoireDto>($"{BaseUrl}/{id}");
        }

        public async Task<MemoireDto> CreateAsync(CreateMemoireDto dto)
        {
            var response = await _http.PostAsJsonAsync(BaseUrl, dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MemoireDto>() ?? throw new Exception("Failed to create");
        }

        public async Task<bool> UpdateAsync(int id, MemoireDto dto)
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
