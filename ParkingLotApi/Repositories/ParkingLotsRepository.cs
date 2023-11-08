using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Model;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName);

            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLots(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }

        public async Task<long> DeleteParkingLot(string iD)
        {
            var result = await _parkingLotCollection.DeleteOneAsync(x => x.Id == iD);
            return result.DeletedCount;
        }

        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await _parkingLotCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ParkingLot?> GetByIdAsync(string iD)
        {
            var parkingLot = await _parkingLotCollection.Find(x => x.Id == iD).FirstOrDefaultAsync();
            if (parkingLot == null)
            {
                return null;
            }
            return parkingLot;
        }
    }
}
