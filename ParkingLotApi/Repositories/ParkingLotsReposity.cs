using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
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

        public async Task<List<ParkingLotDto>> GetPagedData(int skip, int pageSize)
        {
            var filter = Builders<ParkingLot>.Filter.Empty;
            var result = await _parkingLotCollection.Find(filter)
                                         .Skip(skip)
                                         .Limit(pageSize)
                                         .ToListAsync();
            var dtoResult = result.Select(parkingLot => new ParkingLotDto
            {
                Name = parkingLot.Name,
                Capacity = parkingLot.Capacity,
                Location = parkingLot.Location
            }).ToList();
            return dtoResult;
        }

        public async Task<ParkingLotDto?> GetAsync(string id)
        {
            var parkingLot = await _parkingLotCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (parkingLot is null)
            {
                return null;
            }
            var parkingLotDtos = new ParkingLotDto
            {
                Name = parkingLot.Name,
                Capacity = parkingLot.Capacity,
                Location = parkingLot.Location
            };
            return parkingLotDtos;

        }

        public async Task ReplaceAsync(string id, ParkingLotCapacityDto parkingLotCapacityDto)
        {
            var parkinglotToBeUpdated = await _parkingLotCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            var parkingLot = new ParkingLot
            {
                Id = id,
                Name = parkinglotToBeUpdated.Name,
                Location = parkinglotToBeUpdated.Location,
                Capacity = parkingLotCapacityDto.Capacity,
            };

            if (parkingLotCapacityDto.Capacity < 10)
            {
                throw new InvalidCapacityException("error");
            }
            else
            {
                var result = await _parkingLotCollection.ReplaceOneAsync(x => x.Id == id, parkingLot);
            }

        }
    }
}
