using HousesPapon.Communication.Enums;

namespace HousesPapon.Communication.Responses.Tenants
{
    public class ResponseGetTenantPayments
    {
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
