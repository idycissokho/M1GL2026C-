using M1GLSERVER.DTOs;
using M1GLSERVER.EntityE2E;

namespace M1GLSERVER.Services.interfaces
{
    public interface IMemoireService
    {
        Task<IEnumerable<MemoireDto>> GetAllAsync();
        Task<MemoireDto?> GetByIdAsync(int id);
        Task<MemoireDto> CreateAsync(CreateMemoireDto dto);
        Task<bool> UpdateAsync(int id, UpdateMemoireDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
