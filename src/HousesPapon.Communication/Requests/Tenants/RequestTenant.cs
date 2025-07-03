namespace HousesPapon.Communication.Requests.Tenants
{
    public class RequestTenant
    {
        public string Name { get; set; } = string.Empty;
        public DateTime PayDay { get; set; }
        public DateTime EntranceDate { get; set; }
        public long HouseId { get; set; }
        public string CPF { get; set; } = string.Empty;
    }
}
