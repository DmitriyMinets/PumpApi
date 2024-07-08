using Database.Models;

namespace Database
{
    public class Initializer
    {
        public static void InitializeDB(ApplicationContext context)
        {
            if (!context.Pumps.Any())
            {
                var pumps = GetPumps();
                context.Pumps.AddRange(pumps);
                context.SaveChanges();
            }
        }

        private static List<Pump> GetPumps()
        {
            var listMotors = GetMotors();
            var listMaterials = GetMaterilals();
            var listPumps = new List<Pump>()
            {
                new()
                {
                    Name = "Насос 1",
                    MaxPressure = 10.5,
                    LiquidTemperature = 90,
                    Weight = 15,
                    Price = 1568.15M,
                    Description = "Описание насоса-1",
                    Motor = listMotors[0],
                    BodyMaterial = listMaterials[0],
                    ImpellerMaterial = listMaterials[1],
                },
                new()
                {
                    Name = "Насос 2",
                    MaxPressure = 15.2,
                    LiquidTemperature = 85,
                    Weight = 20,
                    Price = 1899.99M,
                    Description = "Описание насоса-2",
                    Motor = listMotors[1],
                    BodyMaterial = listMaterials[1],
                    ImpellerMaterial = listMaterials[2],
                },
                new()
                {
                    Name = "Насос 3",
                    MaxPressure = 12.8,
                    LiquidTemperature = 95,
                    Weight = 18,
                    Price = 1749.75M,
                    Description = "Описание насоса-3",
                    Motor = listMotors[2],
                    BodyMaterial = listMaterials[0],
                    ImpellerMaterial = listMaterials[2],
                },
                new()
                {
                    Name = "Насос 4",
                    MaxPressure = 13.8,
                    LiquidTemperature = 94,
                    Weight = 18,
                    Price = 1749.75M,
                    Description = "Описание насоса-4",
                    Motor = listMotors[2],
                    BodyMaterial = listMaterials[3],
                    ImpellerMaterial = listMaterials[4],
                },
                new()
                {
                    Name = "Насос 5",
                    MaxPressure = 13.8,
                    LiquidTemperature = 94,
                    Weight = 18,
                    Price = 1749.75M,
                    Description = "Описание насоса-5",
                    Motor = listMotors[2],
                    BodyMaterial = listMaterials[3],
                    ImpellerMaterial = listMaterials[4],
                },
            };
            return listPumps;
        }
        private static List<Material> GetMaterilals()
        {
            var listMaterial = new List<Material>()
            {
                new()
                {
                    Name = "Материал-1",
                    Description = "Описание материала-1"
                },
                new()
                {
                    Name = "Материал-2",
                    Description = "Описание материала-2"
                },
                new()
                {
                    Name = "Материал-3",
                    Description = "Описание материала-3"
                },
                new()
                {
                    Name = "Материал-4",
                    Description = "Описание материала-4"
                },
                new()
                {
                    Name = "Материал-5",
                    Description = "Описание материала-5"
                }
            };

            return listMaterial;
        }

        private static List<Motor> GetMotors()
        {
            var listMotor = new List<Motor>()
            {
                new()
                {
                    Name = "Мотор-1",
                    Power = 5,
                    Current = 16,
                    RatedSpeed = 1000,
                    Description = "Описание мотора-1",
                    Price = 500M,
                },
                new()
                {
                    Name = "Мотор-2",
                    Power = 7.5,
                    Current = 20,
                    RatedSpeed = 1200,
                    Description = "Описание мотора-2",
                    Price = 700M,
                },
                new()
                {
                    Name = "Мотор-3",
                    Power = 10,
                    Current = 25,
                    RatedSpeed = 1500,
                    Description = "Описание мотора-3",
                    Price = 1000M,
                },
            };
            return listMotor;
        }
    }
}
