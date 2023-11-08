using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForcastControllerTest : TestBase
    {
        public WeatherForcastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        { 

        }

        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecast()
        {
            HttpClient httpClient = GetClient();
            HttpResponseMessage response = await httpClient.GetAsync("/WeatherForecast");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
