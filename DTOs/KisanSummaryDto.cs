// DTOs/KisanSummaryDto.cs
namespace KisanApi.DTOs
{
    public class KisanSummaryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal TotalZameen { get; set; }
        public decimal OwnZameen { get; set; }
        public decimal LeaseZameen { get; set; }
        public decimal FreeZameen { get; set; }
        public decimal TotalLeaseAmount { get; set; }

        // Flat summaries — no nested navigation
        public List<OzarSummaryDto> Ozars { get; set; } = new();
        public List<ZameenSummaryDto> Zameens { get; set; } = new();
    }

    public class OzarSummaryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public int Quantity { get; set; }
        // No KisanId, no Kisan nav — stops the cycle
    }

    public class ZameenSummaryDto
    {
        public int Id { get; set; }
        public decimal TotalAcre { get; set; }
        public bool IsLease { get; set; }
        public decimal LeaseAmount { get; set; }
        public string? Location { get; set; }
        // No KisanId, no Kisan nav — stops the cycle
    }
}