namespace HousesPapon.Domain.Entities
{
    public class House
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public Tenant? Tenant { get; set; }
    }   
}
