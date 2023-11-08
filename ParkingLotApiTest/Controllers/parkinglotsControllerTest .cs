using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ParkingLotApi;
using ParkingLotApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class parkinglotsControllerTest : TestBase
    {
        public parkinglotsControllerTest(WebApplicationFactory<Program> factory): base(factory) 
        {

        }

        [Fact]
        public async Task Should_return_400_when_create_parkinglot_given_wrong_capacity()
        {
            ParkingLotDto parkinglotwithwrongcapacity = new ParkingLotDto()
            {
                Name = "xianke",
                Location = "bj",
                Capacity = 9

            };
            HttpClient httpClient = GetClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/parkinglots", parkinglotwithwrongcapacity);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
