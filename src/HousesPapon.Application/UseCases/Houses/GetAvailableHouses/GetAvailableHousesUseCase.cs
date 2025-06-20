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

        public async Task<List<ResponseGetAvailableHouses>> Execute()
        {
            var availableHouses = await _repository.GetAvailableHouses();

            return availableHouses.Select(h => new ResponseGetAvailableHouses
            {
                Id = h.Id,
                CreatedAt = h.CreatedAt,
                Number = h.Number,
                Price = h.Price
            }).ToList();
        }
    }
}
