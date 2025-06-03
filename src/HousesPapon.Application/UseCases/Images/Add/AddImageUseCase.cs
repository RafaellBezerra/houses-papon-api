using HousesPapon.Communication.Requests.Images;
using HousesPapon.Communication.Responses.Images;
using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Image;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Images.Add
{
    public class AddImageUseCase : IAddImageUseCase
    {
        private readonly IImageWriteOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddImageUseCase(IImageWriteOnlyRepository repository, IUnitOfWork unitOfWork, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _existenceCheckerRepository = existenceCheckerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAddImage> Execute(RequestAddImage request)
        {
            await Validate(request);

            var image = new Image
            {
                Url = request.Url,
                HouseId = request.HouseId,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.Add(image);
            await _unitOfWork.Commit();

            return new ResponseAddImage
            {
                CreatedAt = image.CreatedAt,
                HouseId = image.HouseId,
                Url = image.Url,
                Id = image.Id
            };
        }

        private async Task Validate(RequestAddImage request)
        {
            var errorMessages = new List<string>();
            if (string.IsNullOrWhiteSpace(request.Url)) errorMessages.Add(ResourceErrorMessages.URL_EMPTY);

            var houseExit = await _existenceCheckerRepository.HouseExist(request.HouseId);
            if (!houseExit)
                errorMessages.Add(ResourceErrorMessages.HOUSE_NOT_FOUND);

            if (errorMessages.Count != 0)
                throw new ErrorOnValidationException(errorMessages);
        } 
    }
}
