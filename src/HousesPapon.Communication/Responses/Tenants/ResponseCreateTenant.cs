namespace HousesPapon.Communication.Responses.Tenants
{
    public class ResponseCreateTenant
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsInDebit { get; set; }
        public DateTime PayDay { get; set; }
        public DateTime EntranceDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public long HouseId { get; set; }
        public string CPF { get; set; } = string.Empty;
    }
}
