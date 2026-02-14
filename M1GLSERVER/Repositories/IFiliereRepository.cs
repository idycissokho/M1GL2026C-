using M1GLSERVER.EntityE2E;

namespace M1GLSERVER.Repositories
{
    public interface IFiliereRepository
    {
        Task<IEnumerable<Filiere>> GetAllAsync();
        Task<Filiere?> GetByIdAsync(int id);
        Task<Filiere> CreateAsync(Filiere filiere);
        Task<bool> UpdateAsync(Filiere filiere);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
