namespace DecoratorProxyPattern.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
