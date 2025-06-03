using FluentValidation;
using HousesPapon.Communication.Requests.User;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
                .EmailAddress().When(u => string.IsNullOrWhiteSpace(u.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage(ResourceErrorMessages.INVALID_EMAIL);
            RuleFor(u => u.Password).MinimumLength(8).WithMessage(ResourceErrorMessages.INVALID_PASSWORD);
        }
    }
}
