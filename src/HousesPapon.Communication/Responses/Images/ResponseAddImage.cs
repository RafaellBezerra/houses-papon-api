namespace HousesPapon.Communication.Responses.Images
{
    public class ResponseAddImage
    {
        public long Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public long HouseId { get; set; }
    }
}
