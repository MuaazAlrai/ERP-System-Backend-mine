using KisanApi.DTOs;

using KisanApi.Models;

using KisanApi.Repositories;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace KisanApi.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

   
    public class FasalController : ControllerBase
    {
        private readonly IFasalRepository _repository;

        public FasalController(
            IFasalRepository repository)
        {
            _repository = repository;
        }

        // GET ALL

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =
                await _repository.GetAllAsync();

            return Ok(data);
        }

        // GET BY ID

        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetById(int id)
        {
            var data =
                await _repository.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // CREATE

        [HttpPost]
        public async Task<IActionResult>
            Create(FasalDto dto)
        {
            var fasal = new Fasal
            {
                Name = dto.Name,

                AcreUsed = dto.AcreUsed,

                SowingDate = dto.SowingDate,

                HarvestDate = dto.HarvestDate,

                KisanId = dto.KisanId
            };

            var created =
                await _repository.CreateAsync(fasal);

            return Ok(created);
        }

        // UPDATE

        [HttpPut("{id}")]
        public async Task<IActionResult>
            Update(int id, FasalDto dto)
        {
            var existing =
                await _repository.GetByIdAsync(id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = dto.Name;

            existing.AcreUsed = dto.AcreUsed;

            existing.SowingDate = dto.SowingDate;

            existing.HarvestDate = dto.HarvestDate;

            existing.KisanId = dto.KisanId;

            await _repository.UpdateAsync(existing);

            return Ok(existing);
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