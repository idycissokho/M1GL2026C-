using M1GLSERVER.EntityE2E;
using Microsoft.EntityFrameworkCore;

namespace M1GLSERVER.Repositories
{
    public class EtudiantRepository : IEtudiantRepository
    {
        private readonly DbMemoireContextE2E _context;

        public EtudiantRepository(DbMemoireContextE2E context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Etudiant>> GetAllAsync()
        {
            return await _context.Etudiants.OrderBy(e => e.Nom).ToListAsync();
        }

        public async Task<Etudiant?> GetByIdAsync(int id)
        {
            return await _context.Etudiants.FindAsync(id);
        }

        public async Task<Etudiant> CreateAsync(Etudiant etudiant)
        {
            _context.Etudiants.Add(etudiant);
            await _context.SaveChangesAsync();
            return etudiant;
        }

        public async Task<bool> UpdateAsync(Etudiant etudiant)
        {
            _context.Entry(etudiant).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant == null) return false;

            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Etudiants.AnyAsync(e => e.Id == id);
        }
    }
}
