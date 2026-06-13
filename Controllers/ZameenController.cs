using KisanApi.DTOs;

using KisanApi.Models;

using KisanApi.Repositories;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace KisanApi.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

  
    public class ZameenController : ControllerBase
    {
        private readonly IZameenRepository _repository;

        private readonly IKisanRepository _kisanRepository;

        public ZameenController(
            IZameenRepository repository,
            IKisanRepository kisanRepository)
        {
            _repository = repository;

            _kisanRepository = kisanRepository;
        }

        // GET ALL

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =
                await _repository.GetAllAsync();

            return Ok(data);
        }

        // CREATE

        [HttpPost]
        public async Task<IActionResult>
            Create(ZameenDto dto)
        {
            var zameen = new Zameen
            {
                TotalAcre = dto.TotalAcre,

                IsLease = dto.IsLease,

                LeaseAmount = dto.LeaseAmount,

                LeaseAmountPerAcre =
                    dto.LeaseAmountPerAcre,

                Location = dto.Location,

                KisanId = dto.KisanId
            };

            var created =
                await _repository.CreateAsync(zameen);

            // AUTO UPDATE KISAN TOTALS

            var kisan =
                await _kisanRepository
                .GetByIdAsync(dto.KisanId);

            if (kisan != null)
            {
                // Total Land

                kisan.TotalZameen =
                    kisan.Zameens.Sum(x => x.TotalAcre);

                // Lease Land

                kisan.LeaseZameen =
                    kisan.Zameens
                    .Where(x => x.IsLease)
                    .Sum(x => x.TotalAcre);

                // Own Land

                kisan.OwnZameen =
                    kisan.Zameens
                    .Where(x => !x.IsLease)
                    .Sum(x => x.TotalAcre);

                // Total Lease Amount

                kisan.TotalLeaseAmount =
                    kisan.Zameens
                    .Where(x => x.IsLease)
                    .Sum(x => x.LeaseAmount);

                // Free Land

                decimal usedLand =
                    kisan.Fasals.Sum(x => x.AcreUsed);

                kisan.FreeZameen =
                    kisan.TotalZameen - usedLand;

                await _kisanRepository
                    .UpdateAsync(kisan);
            }

            return Ok(created);
        }

        // DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok("Deleted Successfully");
        }
    }
}