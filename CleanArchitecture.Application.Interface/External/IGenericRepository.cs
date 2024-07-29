namespace CleanArchitecture.Application.Interface.External
{
    public interface IGenericRepository<T> where T : class
    {
        T Get();
    }
}
