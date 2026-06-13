using KisanApi.Models;

namespace KisanApi.Repositories
{
    public interface IFasalRepository
    {
        Task<IEnumerable<Fasal>> GetAllAsync();

        Task<Fasal?> GetByIdAsync(int id);

        Task<Fasal> CreateAsync(Fasal fasal);

        Task UpdateAsync(Fasal fasal);

        Task DeleteAsync(int id);
    }
}