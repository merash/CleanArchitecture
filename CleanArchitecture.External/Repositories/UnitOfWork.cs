using CleanArchitecture.Application.Interface.External;

namespace CleanArchitecture.External.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IDiscountRepository Discounts { get; }

        public UnitOfWork(IDiscountRepository discounts)
        {
            Discounts = discounts ?? throw new ArgumentNullException(nameof(discounts));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
