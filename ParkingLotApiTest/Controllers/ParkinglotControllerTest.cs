using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class ParkinglotControllerTest : TestBase
    {
        public ParkinglotControllerTest(WebApplicationFactory<Program> factory) :base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_create_parkinglot_given_capacity_less_than_10()
        {
            HttpClient client = GetClient();
            ParkinglotRequest parkinglotRequest = new ParkinglotRequest() { Name = "Dufu", Capacity = 9, Location = "LA"};
            HttpResponseMessage response = await client.PostAsJsonAsync("/parkinglot", parkinglotRequest);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
