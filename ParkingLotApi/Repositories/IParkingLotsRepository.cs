using ParkingLotApi.Model;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLots(ParkingLot parkingLot);
        public Task<long> DeleteParkingLot(string iD);
        public Task<List<ParkingLot>> GetAllAsync();
        public Task<ParkingLot?> GetByIdAsync(string iD);
        public Task<ParkingLot?> UpdateCapacityAsync(string id, int capacity);
    }
}
