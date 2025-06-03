using HousesPapon.Communication.Responses.Houses;
using HousesPapon.Domain.Repositories.House;

namespace HousesPapon.Application.UseCases.Houses.GetAvailableHouses
{
    public class GetAvailableHousesUseCase : IGetAvailableHousesUseCase
    {
        private readonly IHouseReadOnlyRepository _repository;
        public GetAvailableHousesUseCase(IHouseReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetAvailableHouses> Execute()
        {
            var availableHouses = await _repository.GetAvailableHouses();

            return new ResponseGetAvailableHouses
            {
                Houses = availableHouses.Select(h => new ResponseForGetAvailableHouses
                {
                    Id = h.Id,
                    CreatedAt = h.CreatedAt,
                    Number = h.Number,
                    Price = h.Price
                }).ToList()
            };
        }
    }
}
