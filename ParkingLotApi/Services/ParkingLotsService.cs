using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private int pageSize = 15;
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
                throw new RepeatedNameException();
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
            int start = (int)((page - 1) * pageSize);
            int length = pageSize;
            if ((start + 1) > list.Count)
            {
                throw new Exception();
            }
            if ((start + length) > list.Count)
            {
                length = list.Count - start;
            }
            return list.GetRange(start, length);
        }
        public async Task DeleteParkingLot(string id)
        {
            int result = await parkingLotRepository.DeleteParkingLot(id);
            if (result == 0)
            {
                throw new InvalidIdException();
            }
        }
        public async Task<ParkingLot> GetParkingLot(string id)
        {
            ParkingLot result = await parkingLotRepository.GetParkingLot(id);
            if (result == null)
            {
                throw new InvalidIdException();
            }
            else
            {
                return result;
            }
        }
        public async Task<ParkingLot> ChangeCapacityOfParkingLot(string id, int capacity)
        {
            if (capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            ParkingLot result = await parkingLotRepository.ChangeCapacity(id, capacity);
            if (result == null)
            {
                throw new InvalidIdException();
            }
            else
            {
                return result;
            }
        }
    }
}
