namespace Database.Models
{
    public class Pump : BaseEntity
    {
        public string Name { get; set; } = null!;
        public double MaxPressure { get; set; }
        public double LiquidTemperature { get; set; }
        public double Weight {  get; set; }
        public int MotorId { get; set; }
        public Motor Motor { get; set; } = null!;
        public int BodyMaterialId { get; set; }
        public Material BodyMaterial { get; set; } = null!;
        public int ImpellerMaterialId {  get; set; }
        public Material ImpellerMaterial { get; set; } = null!;
        public string? Description { get; set; } 
        public string? ImageUrl {  get; set; }
        public decimal Price { get; set; }
    }
}
