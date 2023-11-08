using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private int pageSize = 3;
        private IParkingLotRepository parkingLotRepository;
        public ParkingLotsService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            ParkingLot result = await parkingLotRepository.CreateParkingLot(parkingLotDto.ToEntity());
            if (result == null)
            {
                throw new InvalidCapacityException();
            }
            else
            {
                return result;
            }
        }
        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await parkingLotRepository.GetAllParkingLots();
        }
        public async Task<List<ParkingLot>> GetOnePageAsync(int? page)
        {
            List<ParkingLot> list = await GetAllAsync();
            return list.GetRange((int)((page - 1) * pageSize), pageSize);
        }
        public async Task DeleteParkingLot(string id)
        {
            await parkingLotRepository.DeleteParkingLot(id);
            return;
        }
        public async Task<ParkingLot> GetParkingLot(string id)
        {
            return await parkingLotRepository.GetParkingLot(id);
        }
        public async Task<ParkingLot> ChangeCapacityOfParkingLot(string id, int capacity)
        {
            if (capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await parkingLotRepository.ChangeCapacity(id, capacity);
        }
    }
}
