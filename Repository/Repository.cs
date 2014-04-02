using System;

namespace DecoratorProxyPattern.Repository
{
    public class Repository<T> : IRepository<T>
    {
        public void Add(T entity)
        {
            Console.WriteLine("Adding {0}", entity);
        }
        public void Delete(T entity)
        {
            Console.WriteLine("Deleting {0}", entity);
        }
        public T GetById(int id)
        {
            Console.WriteLine("Getting entity {0}", id);
            return default(T);
        }
    }
}
