namespace KisanApi.Models
{
    public class Zameen
    {
        public int Id { get; set; }

        // Acre
        public decimal TotalAcre { get; set; }

        // Own or Lease
        public bool IsLease { get; set; }

        // Lease Details
        public decimal LeaseAmount { get; set; }

        public decimal LeaseAmountPerAcre { get; set; }

        public string Location { get; set; }

        // FK
        public int KisanId { get; set; }

        public Kisan Kisan { get; set; }
    }
}