using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controller
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_then_10()
        {
            HttpClient httpClient = GetClient();
            ParkingLotDto parkingLotLessThanTen = new ParkingLotDto()
            {
                Name = "ABCPark",
                Capacity = 9,
                Location = "ABCStreet"
            };
            HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("/api/ParkingLots", parkingLotLessThanTen);

            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        }
    }
}
