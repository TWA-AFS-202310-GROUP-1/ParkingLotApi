using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
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
            if (parkingLotDto.Capacity < 10)
            {
                return BadRequest();
            }
            return null;
        }
    }
}