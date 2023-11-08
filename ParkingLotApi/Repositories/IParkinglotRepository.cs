using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Model;

namespace ParkingLotApi.Repositories
{
    public interface IParkinglotRepository
    {
        public Task<Parkinglot> CreateParkinglot(Parkinglot parkinglot);
        Task DeleteById(string id);
        Task<Parkinglot> GetById(string id);
        Task<List<Parkinglot>> GetParkinglots();
        Task<List<Parkinglot>> GetParkinglots(int page, int pageSize);
        Task UpdateParkinglot(string id, Parkinglot parkinglot);


    }
    public class ParkinglotRepository : IParkinglotRepository
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _database;
        private readonly IMongoCollection<Parkinglot> _parkinglotCollection;

        public ParkinglotRepository(IOptions<ParkinglotDatabaseSettings> settings)
        {
            _mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = _mongoClient.GetDatabase(settings.Value.DatabaseName);
            _parkinglotCollection = _database.GetCollection<Parkinglot>(Parkinglot.CollectionName);
        }

        public async Task<Parkinglot> CreateParkinglot(Parkinglot parkinglot)
        {
            await _parkinglotCollection.InsertOneAsync(parkinglot);
            return await _parkinglotCollection.Find(item => parkinglot.Name == item.Name).FirstAsync();

        }

        public async Task<List<Parkinglot>> GetParkinglots()
        {
            return await _parkinglotCollection.Find(_ =>true).ToListAsync();
        }

        public async Task DeleteById(string id)
        {
            await _parkinglotCollection.DeleteOneAsync(item =>item.Id == id);
        }

        public async Task<List<Parkinglot>> GetParkinglots(int page, int pageSize)
        {
            var query = _parkinglotCollection.Find(_ => true);
            var parkinglots = await query.Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
            return parkinglots;
        }

        public async Task<Parkinglot> GetById(string id)
        {
            return await _parkinglotCollection.Find(item => id == item.Id).FirstAsync();
        }

        public async Task UpdateParkinglot(string id, Parkinglot parkinglot)
        {
            await _parkinglotCollection.ReplaceOneAsync(p => p.Id == id, parkinglot);
        }

    }
}