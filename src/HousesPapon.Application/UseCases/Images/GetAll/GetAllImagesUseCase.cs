using HousesPapon.Communication.Responses.Images;
using HousesPapon.Domain.Repositories.Image;

namespace HousesPapon.Application.UseCases.Images.GetAll
{
    public class GetAllImagesUseCase : IGetAllImagesUseCase
    {
        private readonly IImageReadOnlyRepository _repository;
        public GetAllImagesUseCase(IImageReadOnlyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseGetAllImages> Execute()
        {
            var images = await _repository.GetAll();

            return new ResponseGetAllImages
            {
                Images = images.Select(i => new ResponseForGetAllImages
                {
                    CreatedAt = i.CreatedAt,
                    HouseId = i.HouseId,
                    Id = i.Id,
                    Url = i.Url
                }).ToList()
            };
        }
    }
}
