using HousesPapon.Communication.Responses.Houses;
using HousesPapon.Domain.Repositories.House;

namespace HousesPapon.Application.UseCases.Houses.GetAll
{
    public class GetAllHousesUseCase : IGetAllHousesUseCase
    {
        private readonly IHouseReadOnlyRepository _repository;
        public GetAllHousesUseCase(IHouseReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResponseGetAllHouses>> Execute()
        {
            var houses = await _repository.GetAll();

            return houses.Select(x => new ResponseGetAllHouses
            {
                Id = x.Id,
                Number = x.Number,
                Price = x.Price,
                CreatedAt = x.CreatedAt,
                Tenant = x.Tenant?.Name
            }).ToList();
        }
    }
}


