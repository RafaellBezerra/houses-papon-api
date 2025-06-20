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

        public async Task<List<ResponseGetHouseContracts>> Execute(long id)
        {
            var houseExist = await _existenceCheckerRepository.HouseExist(id);
            if (!houseExist) throw new NotFoundException(ResourceErrorMessages.HOUSE_NOT_FOUND);

            var contracts = await _repository.GetHouseContractsById(id);

            return contracts.Select(c => new ResponseGetHouseContracts
            {
                Url = c.Url,
                BeginDate = c.BeginDate,
                CreatedAt = c.CreatedAt,
                EndDate = c.EndDate,
                HouseId = c.HouseId,
                Id = c.Id,
                TenantId = c.TenantId
            }).ToList();
        }
    }
}
