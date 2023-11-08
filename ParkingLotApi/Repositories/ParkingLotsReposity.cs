using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsReposity : IParkingLotsReposity
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotsReposity(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var result = await _parkingLotCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result is null)
            {
                return false;
            }
            await _parkingLotCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }
    }
}
