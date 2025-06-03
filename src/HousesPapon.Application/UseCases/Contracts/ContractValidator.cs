using FluentValidation;
using HousesPapon.Communication.Requests.Contracts;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Contracts
{
    public class ContractValidator : AbstractValidator<RequestContract>
    {
        public ContractValidator()
        {
            RuleFor(c => c.Url).NotEmpty().WithMessage(ResourceErrorMessages.URL_EMPTY);
            RuleFor(c => c.BeginDate).LessThan(x => x.EndDate).WithMessage(ResourceErrorMessages.INVALID_BEGIN_DATE);
            RuleFor(c => c.EndDate).GreaterThan(x => x.BeginDate).WithMessage(ResourceErrorMessages.INVALID_END_DATE);
        }
    }
}
