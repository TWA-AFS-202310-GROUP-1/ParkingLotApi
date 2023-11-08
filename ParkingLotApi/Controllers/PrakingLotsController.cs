using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            _parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLot([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var isSuccessful = await _parkingLotsService.RemoveAsync(id);
            if (!isSuccessful)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ParkingLotDto), 200)]
        [ProducesResponseType(400)]

        public async Task<ActionResult<List<ParkingLotDto>>> GetAll([FromQuery] int page = 1)
        {
            int pageSize = 15;
            var result = await _parkingLotsService.GetAsync(page,pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLotDto>> GetAsync(string id)
        {
            var result = await _parkingLotsService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}