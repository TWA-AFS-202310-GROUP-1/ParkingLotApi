using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.repositories
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
    }
}
