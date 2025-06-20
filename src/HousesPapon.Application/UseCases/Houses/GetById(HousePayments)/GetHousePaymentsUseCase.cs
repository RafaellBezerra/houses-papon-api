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

        public async Task<List<ResponseGetHousePayments>> Execute(long Id)
        {
            var houseExist = await _existenceCheckerRepository.HouseExist(Id);
            if (!houseExist) throw new NotFoundException(ResourceErrorMessages.HOUSE_NOT_FOUND);

            var payments = await _repository.GetHousePaymentsById(Id);

            return payments.Select(p => new ResponseGetHousePayments
            {
                Id = p.Id,
                Amount = p.Amount,
                CreatedAt = p.CreatedAt,
                PaymentMethod = (Communication.Enums.PaymentMethod)p.PaymentMethod,
                TenantId = p.TenantId,
                HouseId = p.HouseId
            }).ToList();
        }
    }
}
