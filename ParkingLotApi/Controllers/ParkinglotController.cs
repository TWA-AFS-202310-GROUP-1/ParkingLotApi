using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<Parkinglot> Create(ParkinglotRequest parkinglotRequest)
        {
            return StatusCode(StatusCodes.Status201Created, parkinglotService.CreateParkinglot(parkinglotRequest));
        }
    }
}