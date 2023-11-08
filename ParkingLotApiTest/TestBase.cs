using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
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

        protected WebApplicationFactory<Program> Factory { get; }
        protected HttpClient GetClient() 
        { 
            return Factory.CreateClient(); 
        }
    }
}
