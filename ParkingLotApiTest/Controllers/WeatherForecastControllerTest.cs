using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ParkingLotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest : TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory): base(factory) 
        {

        }

        [Fact]
        public async Task Should_return_correct_when_get_weather_forecast()
        {
            HttpClient httpClient = GetClient();
            HttpResponseMessage response = await httpClient.GetAsync("/WeatherForecast");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
