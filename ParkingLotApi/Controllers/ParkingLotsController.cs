using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Services;
using System.Runtime.CompilerServices;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService parkingLotsService;

        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this.parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLot)
        {
            if (parkingLot.Capacity < 10)
            {
                return BadRequest();
            }

            return Ok(parkingLot);
        }
    }
}