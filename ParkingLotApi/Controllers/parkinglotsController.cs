using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class parkinglotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService;
        public parkinglotsController(ParkingLotsService parkingLotsService)
        {
            this._parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            //try
            //{
            //    return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
            //}
            //catch (InvalidCapacityException ex)
            //{
            //    return BadRequest();
            //}
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
            //return StatusCode(StatusCodes.Status100Continue, await _parkingLotsService.AddAsync(parkingLotDto));
        }
    }
}