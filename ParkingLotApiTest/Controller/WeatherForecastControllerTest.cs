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
        public async Task Should_return_correctly_when_get_weather_forcast()
        {
            // Given & When
            HttpClient httpClient = GetClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("/api/WeatherForecast");

            // Then
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }
    }
}
