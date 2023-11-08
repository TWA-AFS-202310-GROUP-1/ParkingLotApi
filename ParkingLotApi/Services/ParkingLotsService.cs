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

        public async Task<bool> RemoveAsync(string id)
        {
            return await parkingLotsReposity.RemoveAsync(id);
        }

        public async Task<List<ParkingLotDto>> GetAsync(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return await parkingLotsReposity.GetPagedData(skip, pageSize);
        }

        public async Task<ParkingLotDto> GetAsync(string id)
        {
            return await parkingLotsReposity.GetAsync(id);
        }

        public async Task<ParkingLotCapacityDto> ReplaceAsync(string id, ParkingLotCapacityDto parkingLotCapacityDto)
        {
            if (string.IsNullOrEmpty(id) || parkingLotCapacityDto is null)
            {
                return null;
            }

            var parkingLot = await parkingLotsReposity.GetAsync(id);

            if (parkingLot is null)
            {
                return null;
            }
            else
            {
                await parkingLotsReposity.ReplaceAsync(id, parkingLotCapacityDto);
            }

            return parkingLotCapacityDto;
        }
    }
}
