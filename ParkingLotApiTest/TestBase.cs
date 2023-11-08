using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        public TestBase(WebApplicationFactory<Program> factory) 
        {
            this.Factory = factory;
        }

        public WebApplicationFactory<Program> Factory { get; }

        public HttpClient GetClient()
        {
            return Factory.CreateClient();
        }
    }
}
