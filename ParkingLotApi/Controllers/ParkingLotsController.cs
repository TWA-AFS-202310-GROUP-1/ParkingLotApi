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
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await parkingLotsService.AddAsync(parkingLotDto));
        }
        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotsAsync([FromQuery] int? page)
        {
            if (page == null)
            {
                return StatusCode(StatusCodes.Status200OK, await parkingLotsService.GetAllAsync());
            }
            return StatusCode(StatusCodes.Status200OK, await parkingLotsService.GetOnePageAsync(page));
        }
        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> DeleteParkingLotAsync(string id)
        {
            await parkingLotsService.DeleteParkingLot(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotAsync(string id)
        {
            return StatusCode(StatusCodes.Status200OK, await parkingLotsService.GetParkingLot(id));
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<ParkingLot>> ChangeCapacityOfParkingLotAsync(string id, CapacityDto capacityDto)
        {
            return StatusCode(StatusCodes.Status200OK, 
                await parkingLotsService.ChangeCapacityOfParkingLot(id, capacityDto.Capacity));
        }
    }
}