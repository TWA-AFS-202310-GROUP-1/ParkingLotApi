using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Model;
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

        [Fact]
        public async Task Should_return_correct_Parkinglot_object_when_create_parkinglot_given_a_parkinglotRequest()
        {
            HttpClient client = GetClient();
            ParkinglotRequest parkinglotRequest = new ParkinglotRequest() { Name = "Dufu", Capacity = 15, Location = "LA" };
            HttpResponseMessage response = await client.PostAsJsonAsync("/parkinglot", parkinglotRequest);
            var result = await response.Content.ReadFromJsonAsync<Parkinglot>();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(result.Id);
            Assert.Equal(parkinglotRequest.Name, result.Name);
        }
    }
}
