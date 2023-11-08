using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> parkingLotsCollection;
        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDBSettings)
        {
            var mongoClient = new MongoClient(parkingLotDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDBSettings.Value.DatabaseName);
            parkingLotsCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDBSettings.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await parkingLotsCollection.InsertOneAsync(parkingLot);
            return await parkingLotsCollection.Find(x => x.Name == parkingLot.Name).FirstAsync();
        }

        public async Task<bool> RemoveParkingLot(string id)
        {
            var result = await parkingLotsCollection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<List<ParkingLot>> GetAllParkingLot()
        {
            return await parkingLotsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            return await parkingLotsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
