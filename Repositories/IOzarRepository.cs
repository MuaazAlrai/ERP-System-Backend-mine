using KisanApi.Models;

namespace KisanApi.Repositories
{
    public interface IOzarRepository
    {
        Task<IEnumerable<Ozar>> GetAllAsync();

        Task<Ozar?> GetByIdAsync(int id);

        Task<Ozar> CreateAsync(Ozar ozar);

        Task UpdateAsync(Ozar ozar);

        Task DeleteAsync(int id);
    }
}