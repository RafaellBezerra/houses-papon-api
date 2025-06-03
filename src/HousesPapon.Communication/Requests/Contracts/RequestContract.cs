namespace HousesPapon.Communication.Requests.Contracts
{
    public class RequestContract
    {
        public string Url { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public long TenantId { get; set; }
        public long HouseId { get; set; }
    }
}
