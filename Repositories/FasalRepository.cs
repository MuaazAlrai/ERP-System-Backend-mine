using KisanApi.Data;

using KisanApi.Models;

using Microsoft.EntityFrameworkCore;

namespace KisanApi.Repositories
{
    public class FasalRepository : IFasalRepository
    {
        private readonly ApplicationDbContext _context;

        public FasalRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL

        public async Task<IEnumerable<Fasal>>
            GetAllAsync()
        {
            return await _context.Fasals

                .Include(x => x.Kisan)

                .ToListAsync();
        }

        // GET BY ID

        public async Task<Fasal?>
            GetByIdAsync(int id)
        {
            return await _context.Fasals

                .Include(x => x.Kisan)

                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // CREATE

        public async Task<Fasal>
            CreateAsync(Fasal fasal)
        {
            await _context.Fasals.AddAsync(fasal);

            await _context.SaveChangesAsync();

            return fasal;
        }

        // UPDATE

        public async Task UpdateAsync(Fasal fasal)
        {
            _context.Fasals.Update(fasal);

            await _context.SaveChangesAsync();
        }

        // DELETE

        public async Task DeleteAsync(int id)
        {
            var fasal =
                await _context.Fasals.FindAsync(id);

            if (fasal != null)
            {
                _context.Fasals.Remove(fasal);

                await _context.SaveChangesAsync();
            }
        }
    }
}