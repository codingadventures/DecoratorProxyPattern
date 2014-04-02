using System;
using DecoratorProxyPattern.Repository;

namespace DecoratorProxyPattern.Decorator
{
    public class LoggerRepository<T> : IRepository<T>
    {
        private readonly IRepository<T> _decorated;
        public LoggerRepository(IRepository<T> decorated)
        {
            _decorated = decorated;
        }
        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        public void Add(T entity)
        {
            Log("In Logger decorator - Before Adding {0}", entity);
            _decorated.Add(entity);
            Log("In Logger decorator - After Adding {0}", entity);
        }
        public void Delete(T entity)
        {
            Log("In Logger decorator - Before Deleting {0}", entity);
            _decorated.Delete(entity);
            Log("In Logger decorator - After Deleting {0}", entity);
        } 

        public T GetById(int id)
        {
            Log("In Logger decorator - Before Getting Entity {0}", id);
            var result = _decorated.GetById(id);
            Log("In Logger decorator - After Getting Entity {0}", id);
            return result;
        }
    }
}
