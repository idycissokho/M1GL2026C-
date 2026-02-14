using M1GLSERVER.DTOs;

namespace M1GLSERVER.Services
{
    public interface IEncadreurService
    {
        Task<IEnumerable<EncadreurDto>> GetAllAsync();
        Task<EncadreurDto?> GetByIdAsync(int id);
        Task<EncadreurDto> CreateAsync(CreateEncadreurDto dto);
        Task<bool> UpdateAsync(int id, UpdateEncadreurDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
