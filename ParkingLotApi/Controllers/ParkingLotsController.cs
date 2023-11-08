using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
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
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLot)
        {
            return StatusCode(StatusCodes.Status201Created, await parkingLotsService.AddAsync(parkingLot));
        }
        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotsAsync([FromQuery] int? page)
        {
            if(page==null)
            {
                return StatusCode(StatusCodes.Status200OK, await parkingLotsService.GetAllAsync());
            }
            return StatusCode(StatusCodes.Status200OK, await parkingLotsService.GetOnePageAsync(page));
        }
        [HttpDelete]
        public async Task<StatusCodeResult> DeleteParkingLotAsync([FromBody] string id)
        {
            await parkingLotsService.DeleteParkingLot(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}