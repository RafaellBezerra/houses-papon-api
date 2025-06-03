using HousesPapon.Application.UseCases.Contracts.Create;
using HousesPapon.Application.UseCases.Contracts.Delete;
using HousesPapon.Application.UseCases.Contracts.GetAll;
using HousesPapon.Application.UseCases.Contracts.GetById;
using HousesPapon.Application.UseCases.Contracts.Update;
using HousesPapon.Application.UseCases.Houses.GetAll;
using HousesPapon.Application.UseCases.Houses.GetAvailableHouses;
using HousesPapon.Application.UseCases.Houses.GetById;
using HousesPapon.Application.UseCases.Houses.GetById_HouseContracts_;
using HousesPapon.Application.UseCases.Houses.GetById_HousePayments_;
using HousesPapon.Application.UseCases.Images.Add;
using HousesPapon.Application.UseCases.Images.Delete;
using HousesPapon.Application.UseCases.Images.GetAll;
using HousesPapon.Application.UseCases.Images.GetById;
using HousesPapon.Application.UseCases.Login.DoLogin;
using HousesPapon.Application.UseCases.Login.DoLogout;
using HousesPapon.Application.UseCases.Payments.Create;
using HousesPapon.Application.UseCases.Payments.Delete;
using HousesPapon.Application.UseCases.Payments.GetAll;
using HousesPapon.Application.UseCases.Payments.GetById;
using HousesPapon.Application.UseCases.Payments.Update;
using HousesPapon.Application.UseCases.Tenants.Create;
using HousesPapon.Application.UseCases.Tenants.Delete;
using HousesPapon.Application.UseCases.Tenants.GetAll;
using HousesPapon.Application.UseCases.Tenants.GetById;
using HousesPapon.Application.UseCases.Tenants.GetById_TenantContracts_;
using HousesPapon.Application.UseCases.Tenants.GetById_TenantPayments_;
using HousesPapon.Application.UseCases.Tenants.Update;
using HousesPapon.Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace HousesPapon.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }
        
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetAllHousesUseCase, GetAllHousesUseCase>();
            services.AddScoped<IGetHouseByIdUseCase, GetHouseByIdUseCase>();
            services.AddScoped<IGetHousePaymentsUseCase, GetHousePaymentsUseCase>();
            services.AddScoped<IGetHouseContractsUseCase, GetHouseContractsUseCase>();
            services.AddScoped<IGetAvailableHousesUseCase, GetAvailableHousesUseCase>();

            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
            services.AddScoped<IDoLogoutUseCase, DoLogoutUseCase>();

            services.AddScoped<IGetAllTenantsUseCase, GetAllTenantsUseCase>();
            services.AddScoped<IGetTenantByIdUseCase, GetTenantByIdUseCase>();
            services.AddScoped<IGetTenantContractsUseCase, GetTenantContractsUseCase>();
            services.AddScoped<IGetTenantPaymentsUseCase, GetTenantPaymentsUseCase>();
            services.AddScoped<ICreateTenantUseCase, CreateTenantUseCase>();
            services.AddScoped<IDeleteTenantUseCase, DeleteTenantUseCase>();
            services.AddScoped<IUpdateTenantUseCase, UpdateTenantUseCase>();

            services.AddScoped<ICreatePaymentUseCase, CreatePaymentUseCase>();
            services.AddScoped<IGetAllPaymentsUseCase, GetAllPaymentsUseCase>();
            services.AddScoped<IGetPaymentByIdUseCase, GetPaymentByIdUseCase>();
            services.AddScoped<IDeletePaymentUseCase, DeletePaymentUseCase>();
            services.AddScoped<IUpdatePaymentUseCase, UpdatePaymentUseCase>();

            services.AddScoped<ICreateContractUseCase, CreateContractUseCase>();
            services.AddScoped<IDeleteContractUseCase, DeleteContractUseCase>();
            services.AddScoped<IGetAllContractsUseCase, GetAllContractsUseCase>();
            services.AddScoped<IGetContractByIdUseCase, GetContractByIdUseCase>();
            services.AddScoped<IUpdateContractUseCase, UpdateContractUseCase>();

            services.AddScoped<IAddImageUseCase, AddImageUseCase>();
            services.AddScoped<IDeleteImageUseCase, DeleteImageUseCase>();
            services.AddScoped<IGetAllImagesUseCase, GetAllImagesUseCase>();
            services.AddScoped<IGetImageByIdUseCase, GetImageByIdUseCase>();
        }
    }
}
