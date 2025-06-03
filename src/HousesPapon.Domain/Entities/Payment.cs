using HousesPapon.Domain.Enums;

namespace HousesPapon.Domain.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public long TenantId { get; set; }
        public Tenant Tenant { get; set; } = default!;

        public long HouseId { get; set; }
        public House House { get; set; } = default!;
    }
}
