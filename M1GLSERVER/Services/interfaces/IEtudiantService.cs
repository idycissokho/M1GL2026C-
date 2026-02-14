using M1GLSERVER.DTOs;

namespace M1GLSERVER.Services
{
    public interface IEtudiantService
    {
        Task<IEnumerable<EtudiantDto>> GetAllAsync();
        Task<EtudiantDto?> GetByIdAsync(int id);
        Task<EtudiantDto> CreateAsync(CreateEtudiantDto dto);
        Task<bool> UpdateAsync(int id, UpdateEtudiantDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
