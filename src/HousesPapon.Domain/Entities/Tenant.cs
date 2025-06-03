namespace HousesPapon.Domain.Entities
{
    public class Tenant
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsInDebit { get; set; }
        public DateTime PayDay { get; set; }
        public DateTime EntranceDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public House House { get; set; } = default!;
        public long HouseId { get; set; }
    }
}
