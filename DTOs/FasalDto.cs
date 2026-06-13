namespace KisanApi.DTOs
{
    public class FasalDto
    {
        public string? Name { get; set; }

        public decimal AcreUsed { get; set; }

        public DateTime SowingDate { get; set; }

        public DateTime? HarvestDate { get; set; }

        public int KisanId { get; set; }
    }
}