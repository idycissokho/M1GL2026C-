using M1GLSERVER.EntityE2E;
using Microsoft.EntityFrameworkCore;

namespace M1GLSERVER.Repositories
{
    public class EncadreurRepository : IEncadreurRepository
    {
        private readonly DbMemoireContextE2E _context;

        public EncadreurRepository(DbMemoireContextE2E context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Encadreur>> GetAllAsync()
        {
            return await _context.Encadreurs.OrderBy(e => e.Nom).ToListAsync();
        }

        public async Task<Encadreur?> GetByIdAsync(int id)
        {
            return await _context.Encadreurs.FindAsync(id);
        }

        public async Task<Encadreur> CreateAsync(Encadreur encadreur)
        {
            _context.Encadreurs.Add(encadreur);
            await _context.SaveChangesAsync();
            return encadreur;
        }

        public async Task<bool> UpdateAsync(Encadreur encadreur)
        {
            _context.Entry(encadreur).State = EntityState.Modified;
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
            var encadreur = await _context.Encadreurs.FindAsync(id);
            if (encadreur == null) return false;

            _context.Encadreurs.Remove(encadreur);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Encadreurs.AnyAsync(e => e.Id == id);
        }
    }
}
