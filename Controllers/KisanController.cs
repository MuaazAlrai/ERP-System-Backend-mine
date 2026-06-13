// Controllers/KisanController.cs
using KisanApi.DTOs;
using KisanApi.Models;
using KisanApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KisanApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class KisanController : ControllerBase
    {
        private readonly IKisanRepository _repository;

        public KisanController(IKisanRepository repository)
        {
            _repository = repository;
        }

        // GET ALL — returns flat summary, no circular refs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAllAsync();

            var result = data.Select(k => ToSummary(k)).ToList();

            return Ok(result);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var kisan = await _repository.GetByIdAsync(id);

            if (kisan == null)
                return NotFound();

            return Ok(ToSummary(kisan));
        }

        // CREATE — accepts only name/photo/phone
        [HttpPost]
        public async Task<IActionResult> Create(KisanDto dto)
        {
            var kisan = new Kisan
            {
                Name = dto.Name,
                PhotoUrl = dto.PhotoUrl,
                PhoneNumber = dto.PhoneNumber
                // Land totals start at 0; Zameen CRUD updates them
            };

            var created = await _repository.CreateAsync(kisan);

            return Ok(ToSummary(created));
        }

        // UPDATE — only name/photo/phone; land totals are managed by ZameenController
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, KisanDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.PhotoUrl = dto.PhotoUrl;
            existing.PhoneNumber = dto.PhoneNumber;

            await _repository.UpdateAsync(existing);

            return Ok(ToSummary(existing));
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok("Deleted Successfully");
        }

        // Maps Kisan → flat DTO, breaking circular refs
        private static KisanSummaryDto ToSummary(Kisan k) => new()
        {
            Id = k.Id,
            Name = k.Name,
            PhotoUrl = k.PhotoUrl,
            PhoneNumber = k.PhoneNumber,
            TotalZameen = k.TotalZameen,
            OwnZameen = k.OwnZameen,
            LeaseZameen = k.LeaseZameen,
            FreeZameen = k.FreeZameen,
            TotalLeaseAmount = k.TotalLeaseAmount,

            Ozars = (k.Ozars ?? Enumerable.Empty<Ozar>())
                .Select(o => new OzarSummaryDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Brand = o.Brand,
                    Quantity = o.Quantity
                }).ToList(),

            Zameens = (k.Zameens ?? Enumerable.Empty<Zameen>())
                .Select(z => new ZameenSummaryDto
                {
                    Id = z.Id,
                    TotalAcre = z.TotalAcre,
                    IsLease = z.IsLease,
                    LeaseAmount = z.LeaseAmount,
                    Location = z.Location
                }).ToList()
        };
    }
}