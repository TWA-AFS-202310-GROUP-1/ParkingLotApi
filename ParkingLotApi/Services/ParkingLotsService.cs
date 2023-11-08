using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private IParkingLotRepository parkingLotRepository;
        public ParkingLotsService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if(parkingLotDto.Capacity<10)
            {
                throw new InvalidCapacityException();
            }
            return await parkingLotRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }
        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await parkingLotRepository.GetAllParkingLots();
        }
    }
}
