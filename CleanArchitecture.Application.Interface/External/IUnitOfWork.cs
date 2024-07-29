namespace CleanArchitecture.Application.Interface.External
{
    public interface IUnitOfWork : IDisposable
    {
        IDiscountRepository Discounts { get; }
    }
}
