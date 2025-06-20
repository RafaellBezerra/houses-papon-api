using HousesPapon.Communication.Responses.Payments;
using HousesPapon.Domain.Repositories.Payment;

namespace HousesPapon.Application.UseCases.Payments.GetAll
{
    public class GetAllPaymentsUseCase : IGetAllPaymentsUseCase
    {
        private readonly IPaymentReadOnlyRepository _repository;
        public GetAllPaymentsUseCase(IPaymentReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResponseGetAllPayments>> Execute()
        {
            var payments = await _repository.GetAll();

            return payments.Select(t => new ResponseGetAllPayments
            {
                Id = t.Id,
                Amount = t.Amount,
                CreatedAt = t.CreatedAt,
                HouseId = t.HouseId,
                TenantId = t.TenantId,
                PaymentMethod = (Communication.Enums.PaymentMethod)t.PaymentMethod,
            }).ToList();
        }
    }
}
