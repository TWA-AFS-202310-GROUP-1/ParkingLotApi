using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsReposity parkingLotsReposity;

        public ParkingLotsService(IParkingLotsReposity parkingLotsReposity)
        {
            this.parkingLotsReposity = parkingLotsReposity;
        }

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException("error");
            }
            return await parkingLotsReposity.CreateParkingLot(parkingLotDto.ToEntity());
        }
    }
}
