using PumpService.Interface;

namespace PumpService.Models.Request
{
    public class PumpRQ : IValidatable
    {
        public string Name { get; set; } = null!;
        public double MaxPressure { get; set; }
        public double LiquidTemperature { get; set; }
        public double Weight { get; set; }
        public int MotorId { get; set; }
        public int BodyMaterialId { get; set; }
        public int ImpellerMaterialId { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }

        public void Valid()
        {
            if (MaxPressure < 0)
                throw new ArgumentException("Значение максимального давления не может быть меньше нуля");
            if (Weight < 0)
                throw new ArgumentException("Значения веса не может быть меньше нуля");
        }
    }
}
