using PumpService.Interface;

namespace PumpService.Models.Request
{
    public class MotorRQ : IValidatable
    {
        public string Name { get; set; } = null!;
        public double Power { get; set; }
        public double Current { get; set; }
        public double RatedSpeed { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public void Valid()
        {
            if(Power < 0)
                throw new InvalidDataException("Значение мощности не может быть меньше нуля");
            if(Current < 0)
                throw new InvalidDataException("Значение тока не может быть меньше нуля");
            if(RatedSpeed < 0)
                throw new InvalidDataException("Значение номинальной скорости не может быть меньше нуля");
            if (Price < 0)
                throw new InvalidDataException("Значение цены не может быть меньше нуля");
        }
    }
}
