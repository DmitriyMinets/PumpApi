using Database.Models;
using PumpService.Models.Request;

namespace PumpService.Mappers
{
    public static class PumpMapper
    {
        public static Pump Map(this PumpRQ pump)
        {
            return new Pump()
            {
                Name = pump.Name,
                MaxPressure = pump.MaxPressure,
                LiquidTemperature = pump.LiquidTemperature,
                Weight = pump.Weight,
                MotorId = pump.MotorId,
                BodyMaterialId = pump.BodyMaterialId,
                ImpellerMaterialId = pump.ImpellerMaterialId,
                Description = pump.Description,
                Image = pump.Image,
                Price = pump.Price,
            };
        }
    }
}
