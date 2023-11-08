using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Model;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }
        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InValidCapacityException();
            }
            return await parkingLotsRepository.CreateParkingLots(parkingLotDto.ToEntity());
        }

        public async Task<long> DeleteAsync(string iD)
        {
            return await parkingLotsRepository.DeleteParkingLot(iD);
        }

        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await parkingLotsRepository.GetAllAsync();
        }

        public async Task<ParkingLot?> GetParkingLotByIdAsync(string id)
        {
            return await parkingLotsRepository.GetByIdAsync(id);
        }
    }
}
