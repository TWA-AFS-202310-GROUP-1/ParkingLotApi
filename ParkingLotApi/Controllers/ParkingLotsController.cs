using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Model;
using ParkingLotApi.Services;
using System.Text.RegularExpressions;

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

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string Id)
        {
            return StatusCode(StatusCodes.Status204NoContent, await _parkingLotsService.DeleteAsync(Id));
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotsByPageAsync([FromQuery] int? pageIndex)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetByPage(pageIndex));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ParkingLot>> GetByIdAsync(string Id)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetParkingLotByIdAsync(Id));
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ParkingLot>> UpdateCapacityAsync(string Id, int capacity)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.UpdateCapacityAsync(Id, capacity));
        }
    }
}
