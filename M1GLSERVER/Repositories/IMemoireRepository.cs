using M1GLSERVER.EntityE2E;

namespace M1GLSERVER.Repositories
{
    public interface IMemoireRepository
    {
        Task<IEnumerable<Memoire>> GetAllAsync();
        Task<Memoire?> GetByIdAsync(int id);
        Task<Memoire> CreateAsync(Memoire memoire);
        Task<bool> UpdateAsync(Memoire memoire);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
