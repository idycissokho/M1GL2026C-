using M1GLSERVER.EntityE2E;
using Microsoft.EntityFrameworkCore;

namespace M1GLSERVER.Repositories
{
    public class MemoireRepository : IMemoireRepository
    {
        private readonly DbMemoireContextE2E _context;

        public MemoireRepository(DbMemoireContextE2E context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Memoire>> GetAllAsync()
        {
            return await _context.memoires
                .Include(m => m.Filiere)
                .Include(m => m.Encadreur)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
        }

        public async Task<Memoire?> GetByIdAsync(int id)
        {
            return await _context.memoires
                .Include(m => m.Filiere)
                .Include(m => m.Encadreur)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Memoire> CreateAsync(Memoire memoire)
        {
            _context.memoires.Add(memoire);
            await _context.SaveChangesAsync();
            return memoire;
        }

        public async Task<bool> UpdateAsync(Memoire memoire)
        {
            _context.Entry(memoire).State = EntityState.Modified;
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
            var memoire = await _context.memoires.FindAsync(id);
            if (memoire == null) return false;

            _context.memoires.Remove(memoire);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.memoires.AnyAsync(m => m.Id == id);
        }
    }
}
