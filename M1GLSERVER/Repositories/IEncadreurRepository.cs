using M1GLSERVER.EntityE2E;

namespace M1GLSERVER.Repositories
{
    public interface IEncadreurRepository
    {
        Task<IEnumerable<Encadreur>> GetAllAsync();
        Task<Encadreur?> GetByIdAsync(int id);
        Task<Encadreur> CreateAsync(Encadreur encadreur);
        Task<bool> UpdateAsync(Encadreur encadreur);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
