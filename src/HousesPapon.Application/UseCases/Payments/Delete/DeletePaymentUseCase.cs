
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Payment;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Payments.Delete
{
    public class DeletePaymentUseCase : IDeletePaymentUseCase
    {
        private readonly IPaymentWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePaymentUseCase(IPaymentWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(long Id)
        {
            var result = await _repository.Delete(Id);
            if (!result) throw new NotFoundException(ResourceErrorMessages.PAYMENT_NOT_FOUND);

            await _unitOfWork.Commit();
        }
    }
}
