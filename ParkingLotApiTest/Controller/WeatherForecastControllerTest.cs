using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controller
{
    public class WeatherForecastControllerTest : TestBase
    {

        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }
        [Fact]
        public async Task Should_return_correctly_when_get_weather_froecast()
        {
            //Given
            HttpClient client = GetClient();

            //When
            HttpResponseMessage response = await client.GetAsync("/WeatherForecast");

            //Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
