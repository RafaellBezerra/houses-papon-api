namespace HousesPapon.Communication.Requests.Images
{
    public class RequestAddImage
    {
        public string Url { get; set; } = string.Empty;
        public long HouseId { get; set; }
    }
}
