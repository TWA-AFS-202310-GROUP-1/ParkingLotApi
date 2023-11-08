using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        Task<ParkingLot> GetByNameAsync(string name);
        public Task<List<ParkingLot>> GetAllAsync();
        public Task<ParkingLot> GetByIdAsync(string id);
        public Task DeleteByIdAsync(string Id);

    }
}
