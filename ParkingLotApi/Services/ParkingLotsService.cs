using ParkingLotApi.Dtos;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capactiy < 10)
            {
                throw new ArgumentException();
            }
            return null;
        }
    }
}
