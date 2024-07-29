namespace CleanArchitecture.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
    }
}
