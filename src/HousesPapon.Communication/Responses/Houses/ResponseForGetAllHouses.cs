namespace HousesPapon.Communication.Responses.Houses
{
    public class ResponseForGetAllHouses
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Tenant { get; set; }
    }
}
