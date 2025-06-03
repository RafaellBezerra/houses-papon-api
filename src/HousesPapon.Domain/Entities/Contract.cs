namespace HousesPapon.Domain.Entities
{
    public class Contract
    {
        public long Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public long TenantId { get; set; }
        public Tenant Tenant { get; set; } = default!;

        public long HouseId { get; set; }
        public House House { get; set; } = default!;
    }
}
