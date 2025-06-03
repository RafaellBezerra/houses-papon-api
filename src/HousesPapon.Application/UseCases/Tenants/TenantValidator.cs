using FluentValidation;
using HousesPapon.Communication.Requests.Tenants;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Tenants
{
    public class TenantValidator : AbstractValidator<RequestTenant>
    {
        public TenantValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
            RuleFor(t => t.EntranceDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.ENTRANCE_DATE_IN_THE_FUTURE);
            RuleFor(t => t.PayDay).GreaterThanOrEqualTo(x => x.EntranceDate).WithMessage(ResourceErrorMessages.INVALID_PAYDAY);
        }
    }
}
