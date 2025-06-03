using HousesPapon.Communication.Enums;

namespace HousesPapon.Communication.Requests.Payments
{
    public class RequestPayment
    {
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public long TenantId { get; set; }
        public long HouseId { get; set; }
    }
}
