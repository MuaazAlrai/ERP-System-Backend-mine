namespace KisanApi.Models
{
    public class Ozar
    {
        public int Id { get; set; }

        // Tractor, Hal, Rager
        public string Name { get; set; }

        public string Brand { get; set; }

        public int Quantity { get; set; }

        // FK
        public int KisanId { get; set; }

        public Kisan Kisan { get; set; }
    }
}