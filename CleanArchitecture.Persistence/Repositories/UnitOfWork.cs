using CleanArchitecture.Application.Interface.Persistence;

namespace CleanArchitecture.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Products { get; }

        public UnitOfWork(IProductRepository products)
        {
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}