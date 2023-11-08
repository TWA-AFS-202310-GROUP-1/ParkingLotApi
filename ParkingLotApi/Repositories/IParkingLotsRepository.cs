using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        Task<ParkingLot> GetByNameAsync(string name);

        public Task DeleteByIdAsync(string Id);

    }
}
