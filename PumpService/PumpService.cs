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
            Initializer.InitializeDB(_db);
        }

        public async Task AddPump(PumpRQ pump)
        {
            var newPump = pump.Map();
            await _db.Pumps.AddAsync(newPump);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var pump = await _db.Pumps.FindAsync(id) ??
                throw new ArgumentException("Насос не найден");
            _db.Pumps.Remove(pump);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pump>> GetPumps()
        {
            return await _db.AllIncludedPupms().ToArrayAsync();
        }

        public async Task UpdatePump(Pump pump)
        {
            _db.Pumps.Update(pump);
            await _db.SaveChangesAsync();
        }
    }
}
