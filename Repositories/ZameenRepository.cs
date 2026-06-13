using KisanApi.Data;

using KisanApi.Models;

using Microsoft.EntityFrameworkCore;

namespace KisanApi.Repositories
{
    public class ZameenRepository : IZameenRepository
    {
        private readonly ApplicationDbContext _context;

        public ZameenRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL

        public async Task<IEnumerable<Zameen>>
            GetAllAsync()
        {
            return await _context.Zameens

                .Include(x => x.Kisan)

                .ToListAsync();
        }

        // GET BY ID

        public async Task<Zameen?>
            GetByIdAsync(int id)
        {
            return await _context.Zameens

                .Include(x => x.Kisan)

                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // CREATE

        public async Task<Zameen>
            CreateAsync(Zameen zameen)
        {
            await _context.Zameens.AddAsync(zameen);

            await _context.SaveChangesAsync();

            return zameen;
        }

        // UPDATE

        public async Task UpdateAsync(Zameen zameen)
        {
            _context.Zameens.Update(zameen);

            await _context.SaveChangesAsync();
        }

        // DELETE

        public async Task DeleteAsync(int id)
        {
            var zameen =
                await _context.Zameens.FindAsync(id);

            if (zameen != null)
            {
                _context.Zameens.Remove(zameen);

                await _context.SaveChangesAsync();
            }
        }
    }
}