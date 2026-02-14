using M1GLSERVER.EntityE2E;

namespace M1GLSERVER.Services.interfaces
{
    public interface IMemoireService
    {
        Task<List<Memoire>> GetAllAsync();
        Task<Memoire> GetByIdAsync(int id);
        Task<Memoire> CreateAsync(Memoire memoire);
        Task<bool> UpdateAsync(Memoire memoire);
        Task<bool> DeleteAsync(int id);
    }
}
