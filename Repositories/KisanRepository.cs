using KisanApi.Data;

using KisanApi.Models;

using Microsoft.EntityFrameworkCore;

namespace KisanApi.Repositories
{
    public class KisanRepository : IKisanRepository
    {
        private readonly ApplicationDbContext _context;

        public KisanRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL

        public async Task<IEnumerable<Kisan>>
            GetAllAsync()
        {
            return await _context.Kisans

                .Include(x => x.Fasals)

                .Include(x => x.Ozars)

                .Include(x => x.Zameens)

                .ToListAsync();
        }

        // GET BY ID

        public async Task<Kisan?>
            GetByIdAsync(int id)
        {
            return await _context.Kisans

                .Include(x => x.Fasals)

                .Include(x => x.Ozars)

                .Include(x => x.Zameens)

                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // CREATE

        public async Task<Kisan>
            CreateAsync(Kisan kisan)
        {
            await _context.Kisans.AddAsync(kisan);

            await _context.SaveChangesAsync();

            return kisan;
        }

        // UPDATE

        public async Task UpdateAsync(Kisan kisan)
        {
            _context.Kisans.Update(kisan);

            await _context.SaveChangesAsync();
        }

        // DELETE

        public async Task DeleteAsync(int id)
        {
            var kisan =
                await _context.Kisans.FindAsync(id);

            if (kisan != null)
            {
                _context.Kisans.Remove(kisan);

                await _context.SaveChangesAsync();
            }
        }
    }
}