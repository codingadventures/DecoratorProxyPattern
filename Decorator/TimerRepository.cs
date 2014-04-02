using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using DecoratorProxyPattern.Repository;

namespace DecoratorProxyPattern.Decorator
{
    public class TimerRepository<T> : IRepository<T>
    {
        private readonly IRepository<T> _decorated;
        private readonly Stopwatch _stopwatch;
        public TimerRepository(IRepository<T> decorated)
        {
            _decorated = decorated;
            _stopwatch = new Stopwatch();
        }
        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        public void Add(T entity)
        {
            Log("In Timer decorator - Timer - Before Adding {0}", entity);
            _stopwatch.Start();
            Thread.Sleep(73);
            _decorated.Add(entity);
            _stopwatch.Stop();
            Log(string.Format("In Timer decorator - After Adding - {0} - Time {1}", entity, _stopwatch.ElapsedMilliseconds));
            _stopwatch.Reset();
        }
        public void Delete(T entity)
        {
            Log("In Timer decorator - Before Deleting {0}", entity);
            _stopwatch.Start();
            Thread.Sleep(43);
            _decorated.Delete(entity);
            Log(string.Format("In Timer decorator - After Adding - {0} - Time {1}", entity, _stopwatch.ElapsedMilliseconds));
            _stopwatch.Reset();

        }

        public T GetById(int id)
        {
            Log("In Timer decorator - Before Getting Entity {0}", id);
            _stopwatch.Start();
            Thread.Sleep(43);
            var result = _decorated.GetById(id);
            Log(string.Format("In Timer decorator - After Adding - {0} - Time {1}", id, _stopwatch.ElapsedMilliseconds));
            _stopwatch.Reset();
            return result;
        }
    }
}
