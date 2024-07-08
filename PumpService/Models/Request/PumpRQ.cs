using Microsoft.AspNetCore.Http;
using PumpService.Interface;

namespace PumpService.Models.Request
{
    public class PumpRQ : IValidatable
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public double MaxPressure { get; set; }
        public double LiquidTemperature { get; set; }
        public double Weight { get; set; }
        public int MotorId { get; set; }
        public int BodyMaterialId { get; set; }
        public int ImpellerMaterialId { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; }

        public void Valid()
        {
            if (MaxPressure < 0)
                throw new InvalidDataException("Значение максимального давления не может быть меньше нуля");
            if (Weight < 0)
                throw new InvalidDataException("Значения веса не может быть меньше нуля");
            if(Price < 0)
                throw new InvalidDataException("Значение цены не может быть меньше нуля");
        }
    }
}
