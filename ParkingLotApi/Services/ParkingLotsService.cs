using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Model;
using ParkingLotApi.Repositories;
using System.Text.RegularExpressions;

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
            if (!ObjectId.TryParse(iD, out _))
            {
                throw new InValidIdException();
            }
            long deleteNo = await parkingLotsRepository.DeleteParkingLot(iD);
            if (deleteNo <= 0)
            {
                throw new ParkingNotFoundException();
            }
            return deleteNo;
        }

        public async Task<List<ParkingLot>> GetByPage(int? pageIndex)
        {
            List<ParkingLot> parkingLots = await parkingLotsRepository.GetAllAsync();
            if (pageIndex == null)
            {
                return parkingLots;
            }
            else if (pageIndex <= 0 || (pageIndex > (((int)pageIndex / 15 + 1))))
            {
                throw new PageOutOfIndexException();
            }
            else
            {
                return parkingLots;
            }
        }

        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await parkingLotsRepository.GetAllAsync();
        }

        public async Task<ParkingLot?> GetParkingLotByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                throw new InValidIdException();
            }
            var parkingLot = await parkingLotsRepository.GetByIdAsync(id);
            if (parkingLot == null)
            {
                throw new ParkingNotFoundException();
            }
            return parkingLot;
        }

        internal async Task<ParkingLot?> UpdateCapacityAsync(string Id, int capacity)
        {
            if (!ObjectId.TryParse(Id, out _))
            {
                throw new InValidIdException();
            }
            if (capacity < 10)
            {
                throw new InValidCapacityException();
            }
            var parkingLot = await parkingLotsRepository.UpdateCapacityAsync(Id, capacity);
            if (parkingLot == null)
            {
                throw new ParkingNotFoundException();
            }
            return parkingLot;
        }
    }
}
