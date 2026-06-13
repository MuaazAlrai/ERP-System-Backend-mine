namespace KisanApi.DTOs
{
    public class ZameenDto
    {
        // Acre

        public decimal TotalAcre { get; set; }

        // Lease or Own

        public bool IsLease { get; set; }

        // Lease Amount

        public decimal LeaseAmount { get; set; }

        // Per Acre Lease

        public decimal LeaseAmountPerAcre { get; set; }

        public string? Location { get; set; }

        public int KisanId { get; set; }
    }
}