using MongoDB.Driver;

namespace ParkingLotApi.Controllers
{
    public  interface IParkinglotRepository
    {
    }
    public class ParkinglotRepository : IParkinglotRepository 
    {
        private MongoClient _mongoClient;

        public ParkinglotRepository(MongoClient mongoClient) 
        {
            _mongoClient = mongoClient;
        }
    }
}