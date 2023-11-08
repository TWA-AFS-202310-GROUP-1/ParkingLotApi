using ParkingLotApi.Model;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLots(ParkingLot parkingLot);
    }
}
