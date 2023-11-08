using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using ParkingLotApi;

namespace ParkingLotApiTest
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> factory;

        public TestBase(WebApplicationFactory<Program> factory)
        {
            this.Factory = factory;
        }

        protected WebApplicationFactory<Program> Factory { get; }

        protected HttpClient GetClient()
        {
            return Factory.CreateClient();
        }
    }
}
