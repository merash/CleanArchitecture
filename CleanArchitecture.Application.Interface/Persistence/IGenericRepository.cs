namespace CleanArchitecture.Application.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        bool Insert(T entity);
        bool Update(T entity);
        T? Get(long ProductId);
        List<T> Get();
    }
}
