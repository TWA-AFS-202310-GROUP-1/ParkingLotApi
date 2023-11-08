using ParkingLotApi.Model;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLots(ParkingLot parkingLot);
        public Task<long> DeleteParkingLot(string iD);
        public Task<ParkingLot> GetByIdAsync(string iD);
    }
}
