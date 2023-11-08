using Microsoft.AspNetCore.Http.HttpResults;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository _parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
        {
            this._parkingLotsRepository = parkingLotsRepository;
        }

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await _parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }
        public async Task DeleteParkingLot(string Id)
        {
            ParkingLot parkingLot = await this._parkingLotsRepository.GetByNameAsync(Id) ?? throw new InvalidIdException("Delete ID invalid");
            await this._parkingLotsRepository.DeleteByIdAsync(parkingLot.Name);
        }

        public async Task<List<ParkingLot>> GetAllAsync(int pageIndex)
        {
            var parkingLotList = await _parkingLotsRepository.GetAllParkingLots();
            return parkingLotList.Skip((int)((pageIndex - 1) * 10)).Take(10).ToList();
        }
    }
}
