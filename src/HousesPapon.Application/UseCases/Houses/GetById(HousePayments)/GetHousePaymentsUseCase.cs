using HousesPapon.Communication.Responses.Houses;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.House;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Houses.GetById_HousePayments_
{
    public class GetHousePaymentsUseCase : IGetHousePaymentsUseCase
    {
        private readonly IHouseReadOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        public GetHousePaymentsUseCase(IHouseReadOnlyRepository repository, IReadOnlyExistenceCheckerRepository existenceCheckerRepository  )
        {
            _repository = repository;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task<ResponseGetHousePayments> Execute(long Id)
        {
            var houseExist = await _existenceCheckerRepository.HouseExist(Id);
            if (!houseExist) throw new NotFoundException(ResourceErrorMessages.HOUSE_NOT_FOUND);

            var payments = await _repository.GetHousePaymentsById(Id);

            return new ResponseGetHousePayments
            {
                Payments = payments.Select(x => new ResponseForGetHousePayments
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    PaymentMethod = (Communication.Enums.PaymentMethod)x.PaymentMethod,
                    TenantId = x.TenantId,
                    HouseId = x.HouseId
                }).ToList(),
            };
        }
    }
}
