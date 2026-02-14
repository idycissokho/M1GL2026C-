using M1GLSERVER.EntityE2E;

namespace M1GLSERVER.Repositories
{
    public interface IEtudiantRepository
    {
        Task<IEnumerable<Etudiant>> GetAllAsync();
        Task<Etudiant?> GetByIdAsync(int id);
        Task<Etudiant> CreateAsync(Etudiant etudiant);
        Task<bool> UpdateAsync(Etudiant etudiant);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
