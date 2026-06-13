using KisanApi.Models;

namespace KisanApi.Repositories
{
    public interface IZameenRepository
    {
        Task<IEnumerable<Zameen>> GetAllAsync();

        Task<Zameen?> GetByIdAsync(int id);

        Task<Zameen> CreateAsync(Zameen zameen);

        Task UpdateAsync(Zameen zameen);

        Task DeleteAsync(int id);
    }
}