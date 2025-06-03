using FluentValidation;
using HousesPapon.Communication.Requests.Payments;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Payments
{
    public class PaymentValidator : AbstractValidator<RequestPayment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.NEGATIVE_OR_ZERO_AMOUNT);
            RuleFor(p => p.PaymentMethod).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PAYMENT_METHOD);
        }
    }
}
