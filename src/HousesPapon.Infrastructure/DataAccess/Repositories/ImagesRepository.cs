using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.Image;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess.Repositories
{
    internal class ImagesRepository : IImageReadOnlyRepository, IImageWriteOnlyRepository
    {
        private readonly HousesPaponDbContext _dbContext;
        public ImagesRepository(HousesPaponDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Image image)
        {
            await _dbContext.Images.AddAsync(image);
        }

        public async Task<bool> Delete(long id)
        {
            var image = await _dbContext.Images.FirstOrDefaultAsync(i => i.Id == id);
            if (image is null) return false;

            _dbContext.Images.Remove(image);
            return true;
        }

        public async Task<List<Image>> GetAll()
        {
            return await _dbContext.Images.AsNoTracking().ToListAsync();
        }

        public async Task<Image?> GetImageById(long id)
        {
            return await _dbContext.Images.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
