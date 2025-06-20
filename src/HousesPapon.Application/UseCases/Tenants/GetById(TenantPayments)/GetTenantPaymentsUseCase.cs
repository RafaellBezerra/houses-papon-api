using HousesPapon.Communication.Responses.Tenants;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Tenant;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Tenants.GetById_TenantPayments_
{
    public class GetTenantPaymentsUseCase : IGetTenantPaymentsUseCase
    {
        private readonly ITenantReadOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        public GetTenantPaymentsUseCase(ITenantReadOnlyRepository repository, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task<List<ResponseGetTenantPayments>> Execute(long Id)
        {
            var tenantExist = await _existenceCheckerRepository.TenantExist(Id);
            if (!tenantExist) throw new NotFoundException(ResourceErrorMessages.TENANT_NOT_FOUND);

            var payments = await _repository.GetTenantPaymentsById(Id);

            return payments.Select(x => new ResponseGetTenantPayments
            {
                Amount = x.Amount,
                CreatedAt = x.CreatedAt,
                PaymentMethod = (Communication.Enums.PaymentMethod)x.PaymentMethod
            }).ToList();
        }
    }
}
