using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Model;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkinglotController : ControllerBase
    {
        private ParkringlotService parkinglotService;
        public ParkinglotController(ParkringlotService parkinglotService)
        {
            this.parkinglotService = parkinglotService;
        }

        [HttpPost]
        public async Task<ActionResult<Parkinglot>> Create(ParkinglotRequest parkinglotRequest)
        {
            return StatusCode(StatusCodes.Status201Created, await parkinglotService.CreateParkinglot(parkinglotRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await parkinglotService.DeleteParkinglot(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet]
        public async Task<ActionResult<List<Parkinglot>>> GetParkinglots([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
        {
            var parkinglots = await parkinglotService.GetParkinglots(page, pageSize);
            return Ok(parkinglots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parkinglot>> GetParkinglotById(string id)
        {
            var parkinglot = await parkinglotService.GetParkinglotById(id);
            if (parkinglot == null)
            {
                return NotFound();
            }
            return Ok(parkinglot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCapacity(string id, [FromBody] int newCapacity)
        {
                var parkinglot = await parkinglotService.GetParkinglotById(id);
                if (parkinglot == null)
                {
                    return NotFound();
                }
                parkinglot.Capacity = newCapacity;
                await parkinglotService.UpdateParkinglot(id, parkinglot);
                return Ok();
        }


    }
}