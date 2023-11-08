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
            List<ParkingLot> temp = await parkingLotCollection.Find(x => x.Name == parkingLot.Name).ToListAsync();
            if(temp.Count != 0)
            {
                return null;
            }

            await parkingLotCollection.InsertOneAsync(parkingLot);
            return parkingLot;
        }

        public async Task<List<ParkingLot>> GetAllParkingLots()
        {
            return await parkingLotCollection.Find(x => true).ToListAsync();
        }
        public async Task DeleteParkingLot(string id)
        {
            await parkingLotCollection.DeleteOneAsync(x => x.Id == id);
            return;
        }
        public async Task<ParkingLot> GetParkingLot(string id)
        {
            return await parkingLotCollection.Find(a => a.Id==id).FirstAsync();
        }
        public async Task<ParkingLot> ChangeCapacity(string id, int capacity)
        {
            ParkingLot parkingLot = await parkingLotCollection.Find(x => x.Id==id).FirstAsync();
            parkingLot.Capacity = capacity;
            parkingLotCollection.ReplaceOne((x => x.Id == id), parkingLot);
            return parkingLot;
        }
    }
}
