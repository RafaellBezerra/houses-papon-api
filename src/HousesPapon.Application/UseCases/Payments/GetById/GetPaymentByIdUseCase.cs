using HousesPapon.Communication.Responses.Payments;
using HousesPapon.Domain.Repositories.Payment;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Payments.GetById
{
    public class GetPaymentByIdUseCase : IGetPaymentByIdUseCase
    {
        private readonly IPaymentReadOnlyRepository _repository;
        public GetPaymentByIdUseCase(IPaymentReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetPaymentById> Execute(long Id)
        {
            var payment = await _repository.GetById(Id) ?? throw new NotFoundException(ResourceErrorMessages.PAYMENT_NOT_FOUND);

            return new ResponseGetPaymentById
            {
                Id = payment.Id,
                Amount = payment.Amount,
                CreatedAt = payment.CreatedAt,
                HouseId = payment.HouseId,
                PaymentMethod = (Communication.Enums.PaymentMethod)payment.PaymentMethod,
                TenantId = payment.TenantId
            };
        }
    }
}
