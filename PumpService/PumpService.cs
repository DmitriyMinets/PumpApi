using Database;
using Database.Extantions;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using PumpService.Interface;
using PumpService.Mappers;
using PumpService.Models.Request;

namespace PumpService
{
    public class PumpService : IPumpService
    {
        private readonly ApplicationContext _db;

        public PumpService(ApplicationContext db)
        {
            _db = db;
        }

        public async Task AddMotor(MotorRQ motor)
        {
            var newMotor = motor.Map();
            await _db.Motors.AddAsync(newMotor);
            await _db.SaveChangesAsync();
        }

        public async Task AddPump(PumpRQ pump)
        {
            var newPump = pump.Map();
            await _db.Pumps.AddAsync(newPump);
            await _db.SaveChangesAsync();
        }

        public async Task<string> DeleteById(int id)
        {
            var pump = await _db.Pumps.FindAsync(id) ??
                throw new ArgumentException("Насос не найден");
            var pathToImage = pump.ImageUrl;
            _db.Pumps.Remove(pump);
            await _db.SaveChangesAsync();
            return pathToImage;
        }

        public async Task<IEnumerable<Material>> GetMaterials()
        {
            return await _db.Materials.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<Motor>> GetMotors()
        {
            return await _db.Motors.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<Pump>> GetPumps()
        {
            return await _db.AllIncludedPupms().OrderBy(p => p.Id).ToListAsync();
        }

        public async Task UpdatePump(PumpRQ pump)
        {
            var oldPump = pump.Map();
            _db.Pumps.Update(oldPump);
            await _db.SaveChangesAsync();
        }
    }
}
