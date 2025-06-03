using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Tenant;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Tenants.Delete
{
    public class DeleteTenantUseCase : IDeleteTenantUseCase
    {
        private readonly ITenantWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTenantUseCase(ITenantWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(long Id)
        {
            var deleteTenant = await _repository.Delete(Id);
            if (!deleteTenant) throw new NotFoundException(ResourceErrorMessages.TENANT_NOT_FOUND);

            await _unitOfWork.Commit();
        }
    }
}
