using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
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

        public async Task<ParkingLot> CreateAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException("Capacity should larger than 10");
            }
            return await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var isDelete = await parkingLotsRepository.RemoveParkingLot(id);
            if (!isDelete)
            {
                throw new IdNotFoundException("Delete ID does not exist");
            }
            return true;
        }

        public async Task<List<ParkingLot>> GetAllAsync(int pageIndex)
        {
            var parkingLotList = await parkingLotsRepository.GetAllParkingLot();
            return parkingLotList.Skip((int)((pageIndex - 1) * 15)).Take(15).ToList();
        }
    }
}
