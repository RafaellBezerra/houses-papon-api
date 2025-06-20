namespace HousesPapon.Communication.Responses.Houses
{
    public class ResponseGetHouseContracts
    {
        public long Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public long TenantId { get; set; }
        public long HouseId { get; set; }
    }
}
