using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.Payment;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess.Repositories
{
    internal class PaymentsRepository : IPaymentReadOnlyRepository, IPaymentWriteOnlyRepository, IPaymentUpdateOnlyRepository
    {
        private readonly HousesPaponDbContext _dbContext;
        public PaymentsRepository(HousesPaponDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Payment payment)
        {
            await _dbContext.Payments.AddAsync(payment);
        }

        public async Task<bool> Delete(long id)
        {
            var payment = await _dbContext.Payments.FirstOrDefaultAsync(p => p.Id == id);
            if (payment is null) return false;

            _dbContext.Payments.Remove(payment);
            return true;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _dbContext.Payments.AsNoTracking().ToListAsync();
        }

        async Task<Payment?> IPaymentUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Payment payment)
        {
            _dbContext.Payments.Update(payment);
        }

        async Task<Payment?> IPaymentReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Payments.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
