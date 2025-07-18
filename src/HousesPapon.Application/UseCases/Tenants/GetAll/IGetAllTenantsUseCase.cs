﻿using HousesPapon.Communication.Responses.Tenants;

namespace HousesPapon.Application.UseCases.Tenants.GetAll
{
    public interface IGetAllTenantsUseCase
    {
        Task<List<ResponseGetAllTenants>> Execute();
    }
}
