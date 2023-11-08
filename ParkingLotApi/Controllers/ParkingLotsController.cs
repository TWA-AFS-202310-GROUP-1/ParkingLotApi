using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                return BadRequest();
            }
            return null;
        }
    }
}
