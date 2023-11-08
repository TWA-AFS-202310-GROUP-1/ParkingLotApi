using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Model;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkinglotController : ControllerBase
    {
        private ParkringlotService parkinglotService;
        public ParkinglotController(ParkringlotService parkinglotService)
        {
            this.parkinglotService = parkinglotService;
        }

        [HttpPost]
        public async Task<ActionResult<Parkinglot>> Create(ParkinglotRequest parkinglotRequest)
        {
            return StatusCode(StatusCodes.Status201Created, await parkinglotService.CreateParkinglot(parkinglotRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await parkinglotService.DeleteParkinglot(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}