using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;
using System.Xml.Linq;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotsCollection;
        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName);
            _parkingLotsCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotsCollection.InsertOneAsync(parkingLot);
            return await _parkingLotsCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }
        public async Task<ParkingLot> GetByNameAsync(string name)
        {
            ParkingLot parkingLot = await _parkingLotsCollection.Find(parkingLot => parkingLot.Name == name).FirstOrDefaultAsync();
            return parkingLot;
        }
        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await _parkingLotsCollection.Find(_ => true).ToListAsync();
        }
        public async Task<ParkingLot> GetByIdAsync(string id)
        {
            return await _parkingLotsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteByIdAsync(string Id)
        {
            await _parkingLotsCollection.DeleteOneAsync(parkingLot => parkingLot.Id == Id);
        }

    }
}
