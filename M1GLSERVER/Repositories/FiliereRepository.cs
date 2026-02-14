using M1GLSERVER.EntityE2E;
using Microsoft.EntityFrameworkCore;

namespace M1GLSERVER.Repositories
{
    public class FiliereRepository : IFiliereRepository
    {
        private readonly DbMemoireContextE2E _context;

        public FiliereRepository(DbMemoireContextE2E context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filiere>> GetAllAsync()
        {
            return await _context.Filieres.OrderBy(f => f.Nom).ToListAsync();
        }

        public async Task<Filiere?> GetByIdAsync(int id)
        {
            return await _context.Filieres.FindAsync(id);
        }

        public async Task<Filiere> CreateAsync(Filiere filiere)
        {
            _context.Filieres.Add(filiere);
            await _context.SaveChangesAsync();
            return filiere;
        }

        public async Task<bool> UpdateAsync(Filiere filiere)
        {
            _context.Entry(filiere).State = EntityState.Modified;
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
            var filiere = await _context.Filieres.FindAsync(id);
            if (filiere == null) return false;

            _context.Filieres.Remove(filiere);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Filieres.AnyAsync(f => f.Id == id);
        }
    }
}
