using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Model;
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
            this._parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));

        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string ID)
        {
            long deleteNo = await _parkingLotsService.DeleteAsync(ID);
            if (deleteNo > 0)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotsByPageAsync([FromQuery] int? pageIndex)
        {
            List<ParkingLot> parkingLots = await _parkingLotsService.GetAllAsync();
            if (pageIndex == null)
            {
                return Ok(parkingLots);
            }
            if (pageIndex < 0 || (pageIndex > (((int)pageIndex / 15 + 1))))
            {
                return BadRequest();
            }
            else
            {
                List<ParkingLot> partialParkingLots = parkingLots.Skip(((int)pageIndex - 1) * 15).Take(15).ToList();
                return Ok(partialParkingLots);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ParkingLot>> GetByIdAsync(string Id)
        {
            var parkingLot = await _parkingLotsService.GetParkingLotByIdAsync(Id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return Ok(parkingLot);
        }
    }
}
