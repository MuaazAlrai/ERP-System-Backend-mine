namespace KisanApi.Models
{
    public class Fasal
    {
        public int Id { get; set; }

        // Makai, Gandum, Chawal
        public string Name { get; set; }

        // How many acre used
        public decimal AcreUsed { get; set; }

        public DateTime SowingDate { get; set; }

        public DateTime? HarvestDate { get; set; }

        // FK
        public int KisanId { get; set; }

        public Kisan Kisan { get; set; }
    }
}