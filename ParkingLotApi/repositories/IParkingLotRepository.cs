using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.repositories
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<List<ParkingLot>> GetAllParkingLots();
        public Task<int> DeleteParkingLot(string id);
        public Task<ParkingLot> GetParkingLot(string id);
        public Task<ParkingLot> ChangeCapacity(string id, int capacity);
    }
}
