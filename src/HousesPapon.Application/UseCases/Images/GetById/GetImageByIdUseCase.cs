using HousesPapon.Communication.Responses.Images;
using HousesPapon.Domain.Repositories.Image;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Images.GetById
{
    public class GetImageByIdUseCase : IGetImageByIdUseCase
    {
        private readonly IImageReadOnlyRepository _repository;
        public GetImageByIdUseCase(IImageReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetImageById> Execute(long Id)
        {
            var image = await _repository.GetImageById(Id) ?? throw new NotFoundException(ResourceErrorMessages.IMAGE_NOT_FOUND);

            return new ResponseGetImageById
            {
                Id = image.Id,
                CreatedAt = image.CreatedAt,
                HouseId = image.HouseId,
                Url = image.Url,
            };
        }
    }
}
