using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Model;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkringlotService
    {
        private readonly int _capacity = 10;
        private readonly IParkinglotRepository _parkinglotRepository;
        public ParkringlotService(IParkinglotRepository parkinglotRepository)
        {
            _parkinglotRepository = parkinglotRepository;
        }

        public async Task<Parkinglot> CreateParkinglot(ParkinglotRequest parkinglotRequest)
        {
            if (parkinglotRequest == null || parkinglotRequest.Capacity < _capacity)
            {
                throw new ArgumentException("Capacity is lest than " + _capacity);

            }
            var allParkinglots = await GetParkinglots();
            if(allParkinglots.Find(item => item.Name == parkinglotRequest.Name) != null){
                throw new ArgumentException("Existed same name");
            }
            return await _parkinglotRepository.CreateParkinglot(parkinglotRequest.ToEntity());
        }

        public async Task<List<Parkinglot>> GetParkinglots()
        {
            return await _parkinglotRepository.GetParkinglots();
        }
        public async Task<List<Parkinglot>> GetParkinglots(int page, int pageSize)
        {
            return await _parkinglotRepository.GetParkinglots(page, pageSize);
        }

        public async Task DeleteParkinglot(string id)
        {
            await _parkinglotRepository.DeleteById(id);
        }

        public async Task<Parkinglot> GetParkinglotById(string id)
        {
            return await _parkinglotRepository.GetById(id);
        }
    }
}