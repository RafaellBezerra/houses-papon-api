using HousesPapon.Communication.Responses.Houses;
using HousesPapon.Domain.Repositories.House;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Houses.GetById
{
    public class GetHouseByIdUseCase : IGetHouseByIdUseCase
    {
        private readonly IHouseReadOnlyRepository _repository;
        public GetHouseByIdUseCase(IHouseReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetHouseById> Execute(long Id)
        {
            var house = await _repository.GetById(Id) ?? throw new NotFoundException(ResourceErrorMessages.HOUSE_NOT_FOUND);

            return new ResponseGetHouseById
            {
                Number = house.Number,
                Price = house.Price,
                CreatedAt = house.CreatedAt
            };
        }
    }
}
