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

        public async Task<ResponseGetAllPayments> Execute()
        {
            var payments = await _repository.GetAll();

            return new ResponseGetAllPayments
            {
                Payments = payments.Select(t => new ResponseForGetAllPayments
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    CreatedAt = t.CreatedAt,
                    HouseId = t.HouseId,
                    TenantId = t.TenantId,
                    PaymentMethod = (Communication.Enums.PaymentMethod)t.PaymentMethod,
                }).ToList()
            };
        }
    }
}
