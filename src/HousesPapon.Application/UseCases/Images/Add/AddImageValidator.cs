using FluentValidation;
using HousesPapon.Communication.Requests.Images;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Images.Add
{
    public class AddImageValidator : AbstractValidator<RequestAddImage>
    {
        public AddImageValidator()
        {
            RuleFor(i => i.Url).Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute)).WithMessage(ResourceErrorMessages.URL_EMPTY);
        }
    }
}
