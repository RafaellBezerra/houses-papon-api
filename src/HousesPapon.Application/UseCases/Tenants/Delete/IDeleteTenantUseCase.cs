namespace HousesPapon.Application.UseCases.Tenants.Delete
{
    public interface IDeleteTenantUseCase
    {
        Task Execute(long Id);
    }
}
