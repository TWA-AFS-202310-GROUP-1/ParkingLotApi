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
        public async Task Should_return_400_when_create_parkinglot_given_capacity_less_than_10()
        {
            //Given
            HttpClient client = GetClient();

            //When
            ParkingLotDto parkingLotDtoWithCapacityLessThan10 = new ParkingLotDto()
            { 
                Name = "Car1",
                Capacity = 9,
                Location = "Building1"
            };
            HttpResponseMessage response = await client.PostAsJsonAsync("/ParkingLots", parkingLotDtoWithCapacityLessThan10);

            //Then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
