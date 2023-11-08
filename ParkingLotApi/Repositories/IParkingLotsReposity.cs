using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsReposity
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<bool> RemoveAsync(string id);
        public Task<List<ParkingLotDto>> GetPagedData(int skip, int pageSize);
        public Task<ParkingLotDto?> GetAsync(string id);
    }
}
