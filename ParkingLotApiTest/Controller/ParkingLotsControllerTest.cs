using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controller
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_post_given_parkinglot_with_unvalid_capacity()
        {
            //given and when
            HttpClient httpClient = GetClient();

            ParkingLotDto requestParkingLot = new ParkingLotDto()
            {
                Name = "New ParkingLot",
                Capacity = 9,
                Location = "Ming Street"
            };

            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/ParkingLots", requestParkingLot);

            //then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_return_added_parkinglot_with201_when_post_given_valid_information()
        {
            //given and when
            HttpClient httpClient = GetClient();

            ParkingLotDto requestParkingLot = new ParkingLotDto()
            {
                Name = "New ParkingLot",
                Capacity = 19,
                Location = "Ming Street"
            };

            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/ParkingLots", requestParkingLot);

            //then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
