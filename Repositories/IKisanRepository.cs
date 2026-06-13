using KisanApi.Models;

namespace KisanApi.Repositories
{
    public interface IKisanRepository
    {
        Task<IEnumerable<Kisan>> GetAllAsync();

        Task<Kisan?> GetByIdAsync(int id);

        Task<Kisan> CreateAsync(Kisan kisan);

        Task UpdateAsync(Kisan kisan);

        Task DeleteAsync(int id);
    }
}