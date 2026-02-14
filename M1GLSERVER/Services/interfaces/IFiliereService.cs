using M1GLSERVER.DTOs;

namespace M1GLSERVER.Services
{
    public interface IFiliereService
    {
        Task<IEnumerable<FiliereDto>> GetAllAsync();
        Task<FiliereDto?> GetByIdAsync(int id);
        Task<FiliereDto> CreateAsync(CreateFiliereDto dto);
        Task<bool> UpdateAsync(int id, UpdateFiliereDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
