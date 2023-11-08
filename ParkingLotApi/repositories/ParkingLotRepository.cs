using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IMongoCollection<ParkingLot> parkingLotCollection;
        public ParkingLotRepository(IOptions<ParkingLotDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(settings.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await parkingLotCollection.InsertOneAsync(parkingLot);
            return await parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }

        public async Task<List<ParkingLot>> GetAllParkingLots()
        {
            return await parkingLotCollection.Find(x => true).ToListAsync();
        }
    }
}
