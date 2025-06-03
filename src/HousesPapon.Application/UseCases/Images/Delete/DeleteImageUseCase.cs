using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Image;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Images.Delete
{
    public class DeleteImageUseCase : IDeleteImageUseCase
    {
        private readonly IImageWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteImageUseCase(IImageWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long Id)
        {
            var result = await _repository.Delete(Id);
            if (!result) throw new NotFoundException(ResourceErrorMessages.IMAGE_NOT_FOUND);

            await _unitOfWork.Commit();
        }
    }
}
