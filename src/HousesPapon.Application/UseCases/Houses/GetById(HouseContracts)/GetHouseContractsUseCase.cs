using HousesPapon.Communication.Responses.Houses;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.House;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Houses.GetById_HouseContracts_
{
    public class GetHouseContractsUseCase : IGetHouseContractsUseCase
    {
        private readonly IHouseReadOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        public GetHouseContractsUseCase(IHouseReadOnlyRepository repository, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task<ResponseGetHouseContracts> Execute(long id)
        {
            var houseExist = await _existenceCheckerRepository.HouseExist(id);
            if (!houseExist) throw new NotFoundException(ResourceErrorMessages.HOUSE_NOT_FOUND);

            var contracts = await _repository.GetHouseContractsById(id);

            return new ResponseGetHouseContracts
            {
                Contracts = contracts.Select(x => new ResponseForGetHouseContracts
                {
                    Url = x.Url,
                    BeginDate = x.BeginDate,
                    CreatedAt = x.CreatedAt,
                    EndDate = x.EndDate,
                    HouseId = x.HouseId,
                    Id = x.Id,
                    TenantId = x.TenantId
                }).ToList(),
            };
        }
    }
}
