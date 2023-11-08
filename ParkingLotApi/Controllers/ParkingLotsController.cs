using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService) 
        {
            this.parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await parkingLotsService.CreateAsync(parkingLotDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string id)
        {
            await parkingLotsService.RemoveAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetPageAsync([FromQuery] int pageIndex)
        {
            return Ok(await parkingLotsService.GetAllAsync(pageIndex));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotByIdAsync(string id)
        {
            return Ok(await parkingLotsService.GetAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLot>> PutCapacityAsync(string id, [FromBody] UpdateParkingLotDto updateParkingLotDto)
        {
            return Ok(await parkingLotsService.UpdateCapacityAsync(id, updateParkingLotDto));
        }

    }
}
