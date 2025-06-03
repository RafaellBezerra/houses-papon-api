namespace HousesPapon.Domain.Entities
{
    public class Image
    {
        public long Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public long HouseId { get; set; }
        public House House { get; set; } = default!;
    }
}
