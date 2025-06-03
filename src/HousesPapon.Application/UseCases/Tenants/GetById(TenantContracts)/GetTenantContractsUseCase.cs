using HousesPapon.Communication.Responses.Tenants;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Tenant;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Tenants.GetById_TenantContracts_
{
    public class GetTenantContractsUseCase : IGetTenantContractsUseCase
    {
        private readonly ITenantReadOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        public GetTenantContractsUseCase(ITenantReadOnlyRepository repository, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task<ResponseGetTenantContracts> Execute(long Id)
        {
            var tenantExist = await _existenceCheckerRepository.TenantExist(Id);
            if (!tenantExist) throw new NotFoundException(ResourceErrorMessages.TENANT_NOT_FOUND);

            var contracts = await _repository.GetTenantContractsById(Id);

            return new ResponseGetTenantContracts
            {
                Contracts = contracts.Select(x => new ResponseForGetTenantContracts
                {
                    BeginDate = x.BeginDate,
                    CreatedAt = x.CreatedAt,
                    EndDate = x.EndDate,
                    Url = x.Url
                }).ToList()
            };
        }
    }
}
