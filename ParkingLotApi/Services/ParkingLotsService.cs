using ParkingLotApi.Dtos;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new ArgumentException();
            }
            return null;
        }
    }
}
