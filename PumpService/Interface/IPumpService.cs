using Database.Models;
using PumpService.Models.Request;

namespace PumpService.Interface
{
    public interface IPumpService
    {
        Task<IEnumerable<Pump>> GetPumps();
        Task AddPump(PumpRQ pump);
        Task UpdatePump(Pump pump);
        Task DeleteById(int id);
    }
}
