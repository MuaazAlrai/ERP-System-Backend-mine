using KisanApi.Data;

using KisanApi.Models;

using Microsoft.EntityFrameworkCore;

namespace KisanApi.Repositories
{
    public class OzarRepository : IOzarRepository
    {
        private readonly ApplicationDbContext _context;

        public OzarRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL

        public async Task<IEnumerable<Ozar>>
            GetAllAsync()
        {
            return await _context.Ozars

                .Include(x => x.Kisan)

                .ToListAsync();
        }

        // GET BY ID

        public async Task<Ozar?>
            GetByIdAsync(int id)
        {
            return await _context.Ozars

                .Include(x => x.Kisan)

                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // CREATE

        public async Task<Ozar>
            CreateAsync(Ozar ozar)
        {
            await _context.Ozars.AddAsync(ozar);

            await _context.SaveChangesAsync();

            return ozar;
        }

        // UPDATE

        public async Task UpdateAsync(Ozar ozar)
        {
            _context.Ozars.Update(ozar);

            await _context.SaveChangesAsync();
        }

        // DELETE

        public async Task DeleteAsync(int id)
        {
            var ozar =
                await _context.Ozars.FindAsync(id);

            if (ozar != null)
            {
                _context.Ozars.Remove(ozar);

                await _context.SaveChangesAsync();
            }
        }
    }
}