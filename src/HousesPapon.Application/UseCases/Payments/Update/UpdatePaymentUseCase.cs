using FluentValidation.Results;
using HousesPapon.Communication.Requests.Payments;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Payment;
using HousesPapon.Exception.Resources;
using HousesPapon.Exception;

namespace HousesPapon.Application.UseCases.Payments.Update
{
    public class UpdatePaymentUseCase : IUpdatePaymentUseCase
    {
        private readonly IPaymentUpdateOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePaymentUseCase(IPaymentUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _existenceCheckerRepository = existenceCheckerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(RequestPayment request, long Id)
        {
            await Validate(request);

            var payment = await _repository.GetById(Id) ?? throw new NotFoundException(ResourceErrorMessages.PAYMENT_NOT_FOUND);

            payment.Amount = request.Amount;
            payment.PaymentMethod = (Domain.Enums.PaymentMethod)request.PaymentMethod;
            payment.HouseId = request.HouseId;
            payment.TenantId = request.TenantId;

            _repository.Update(payment);
            await _unitOfWork.Commit();
        }

        private async Task Validate(RequestPayment request)
        {
            var result = new PaymentValidator().Validate(request);

            var houseExist = await _existenceCheckerRepository.HouseExist(request.HouseId);
            if (!houseExist)
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.HOUSE_NOT_FOUND));

            var tenantExist = await _existenceCheckerRepository.TenantExist(request.TenantId);
            if (!tenantExist)
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.TENANT_NOT_FOUND));

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
