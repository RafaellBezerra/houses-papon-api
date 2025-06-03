using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Contract;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Contracts.Delete
{
    public class DeleteContractUseCase : IDeleteContractUseCase
    {
        private readonly IContractWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteContractUseCase(IContractWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long Id)
        {
            var result = await _repository.Delete(Id);
            if (!result) throw new NotFoundException(ResourceErrorMessages.CONTRACT_NOT_FOUND);

            await _unitOfWork.Commit();
        }
    }
}
