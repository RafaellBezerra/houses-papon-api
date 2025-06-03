using FluentValidation.Results;
using HousesPapon.Communication.Requests.Payments;
using HousesPapon.Communication.Responses.Payments;
using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Payment;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Payments.Create
{
    public class CreatePaymentUseCase : ICreatePaymentUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentWriteOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        public CreatePaymentUseCase(IUnitOfWork unitOfWork, IPaymentWriteOnlyRepository repository, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _existenceCheckerRepository = existenceCheckerRepository;
        }
        public async Task<ResponseCreatePayment> Execute(RequestPayment request)
        {
            await Validate(request);

            var payment = new Payment
            {
                Amount = request.Amount,
                PaymentMethod = (Domain.Enums.PaymentMethod)request.PaymentMethod,
                TenantId = request.TenantId,
                HouseId = request.HouseId,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.Add(payment);
            await _unitOfWork.Commit();

            return new ResponseCreatePayment
            {
                Id = payment.Id,
                CreatedAt = payment.CreatedAt,
                Amount = payment.Amount,
                PaymentMethod = request.PaymentMethod,
                TenantId = payment.TenantId,
                HouseId = payment.HouseId
            };
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
