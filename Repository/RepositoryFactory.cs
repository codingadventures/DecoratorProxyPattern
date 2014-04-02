using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecoratorProxyPattern.Decorator;
using DecoratorProxyPattern.Proxy;

namespace DecoratorProxyPattern.Repository
{
    /// <summary>
    /// we can’t call proxy directly, because DynamicProxy<T> isn’t an IRepository<Customer>
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// To use the decorated repository, you must use the GetTransparentProxy method, which will return an instance of IRepository<Customer>. 
        /// Every method of this instance that’s called will go through the proxy’s Invoke method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRepository<T> CreateRepositoryWithProxy<T>()
        {
            var repository = new Repository<T>();

            // var loggerRepository = new LoggerRepository<T>(repository);
            //var timingRepository = new TimerRepository<T>(loggerRepository);

            var dynamicProxy = new DynamicProxy<IRepository<T>>(repository);
            var transparentProxy = dynamicProxy.GetTransparentProxy() as IRepository<T>;

            var timingProxy = new TimerProxy<IRepository<T>>(transparentProxy);

            return timingProxy.GetTransparentProxy() as IRepository<T>;
        }

        public static IRepository<T> CreateRepositoryWithDecorator<T>()
        {
            var repository = new Repository<T>();

            var loggerRepository = new LoggerRepository<T>(repository);
            var timingRepository = new TimerRepository<T>(loggerRepository);

            return timingRepository;
        }

    }
}
