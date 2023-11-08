using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.repositories
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<List<ParkingLot>> GetAllParkingLots();
        public Task DeleteParkingLot(string id);
    }
}
