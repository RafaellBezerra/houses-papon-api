using HousesPapon.Communication.Enums;

namespace HousesPapon.Communication.Responses.Payments
{
    public class ResponseGetPaymentById
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public long TenantId { get; set; }
        public long HouseId { get; set; }
    }
}
