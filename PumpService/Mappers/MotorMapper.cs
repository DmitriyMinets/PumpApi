using Database.Models;
using PumpService.Models.Request;

namespace PumpService.Mappers
{
    public static  class MotorMapper
    {
        public static Motor Map(this MotorRQ motor)
        {
            return new Motor()
            {
                Name = motor.Name,
                Power = motor.Power,
                Price = motor.Price,
                RatedSpeed = motor.RatedSpeed,
                Current = motor.Current,
                Description = motor.Description,
            };
        }
    }
}
