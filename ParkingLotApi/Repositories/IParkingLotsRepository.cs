using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<bool> RemoveParkingLot(string id);
        public Task<List<ParkingLot>> GetAllParkingLot();
        public Task<ParkingLot> GetParkingLotById(string id);
    }
}
