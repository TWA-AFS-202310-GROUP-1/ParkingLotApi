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

        internal async Task<long> DeleteAsync(string iD)
        {
            return await parkingLotsRepository.DeleteParkingLot(iD);

            /*ParkingLot? parkingLot = await parkingLotsRepository.GetByIdAsync(iD);
            if (parkingLot == null)
            {
                return null;
            }
            await parkingLotsRepository.DeleteParkingLot(iD);
            return parkingLot;*/
        }
    }
}
