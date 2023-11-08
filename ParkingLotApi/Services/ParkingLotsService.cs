using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capactiy < 10)
            {
                throw new InValidCapacityException();
            }
            return null;
        }
    }
}
