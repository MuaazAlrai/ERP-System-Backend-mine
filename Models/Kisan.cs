namespace KisanApi.Models
{
    public class Kisan
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhotoUrl { get; set; }

        public string PhoneNumber { get; set; }

        // Total Land
        public decimal TotalZameen { get; set; }

        // Own Land
        public decimal OwnZameen { get; set; }

        // Lease Land
        public decimal LeaseZameen { get; set; }

        // Empty Land
        public decimal FreeZameen { get; set; }

        // Lease Info
        public decimal TotalLeaseAmount { get; set; }

        public decimal LeaseAmountPerAcre { get; set; }

        // Navigation Properties
        public ICollection<Fasal> Fasals { get; set; }

        public ICollection<Ozar> Ozars { get; set; }

        public ICollection<Zameen> Zameens { get; set; }
    }
}