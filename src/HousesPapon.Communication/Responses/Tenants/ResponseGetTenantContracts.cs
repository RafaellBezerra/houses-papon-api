﻿namespace HousesPapon.Communication.Responses.Tenants
{
    public class ResponseGetTenantContracts
    {
        public string Url = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
