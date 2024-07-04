using Database.Models;
using Microsoft.AspNetCore.Mvc;
using PumpService.Interface;
using PumpService.Models.Request;

namespace PumpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpController : ControllerBase
    {
        private readonly IPumpService _pumpService;

        public PumpController(IPumpService pumpService)
        {
            _pumpService = pumpService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetPumps() 
        {
            return Ok(await _pumpService.GetPumps());
        }

        [HttpPost("AddPump")]
        public async Task<IActionResult> AddPumps(PumpRQ pump) 
        {
             await _pumpService.AddPump(pump);
            return Ok();
        }

        [HttpPut("UpdatePump")]
        public async Task<IActionResult> UpdatePumps(Pump pump) 
        {
            await _pumpService.UpdatePump(pump);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleptePump(int id)
        {
            await _pumpService.DeleteById(id);
            return Ok();
        }
    }
}
