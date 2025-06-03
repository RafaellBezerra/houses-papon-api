using FluentValidation.Results;
using HousesPapon.Communication.Requests.User;
using HousesPapon.Communication.Responses.User;
using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.User;
using HousesPapon.Domain.Security.Cryptografy;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IPasswordEncripter _passwordEncripter;
        public RegisterUserUseCase(IUnitOfWork unitOfWork,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IPasswordEncripter passwordEncripter)
        {
            _unitOfWork = unitOfWork;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisterUser> Execute(RequestRegisterUser request)
        {
            await Validate(request);
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                UserIdentifier = Guid.NewGuid()
            };
            user.Password = _passwordEncripter.Encrypt(user.Password);

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

            return new ResponseRegisterUser
            {
                Name = user.Name
            };
        }

        private async Task Validate(RequestRegisterUser request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var existUserWithEmail = await _userReadOnlyRepository.ExistUserWithThisEmail(request.Email);
            if (existUserWithEmail)
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_USED));

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
