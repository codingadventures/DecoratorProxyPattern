using System;
using DecoratorProxyPattern.Decorator;
using DecoratorProxyPattern.Model;
using DecoratorProxyPattern.Repository;

namespace DecoratorProxyPattern
{
    /// <summary>
    /// Taken from
    /// http://msdn.microsoft.com/en-us/magazine/dn574804.aspx
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            NoDecoratorNoProxy();

            OneDecoratorNoProxy();

            TwoDecoratorsNoProxy(); 

            NoDecoratorTwoProxies();
        }
         

        private static void NoDecoratorNoProxy()
        {
            Console.WriteLine("***\r\n Begin program - no logging\r\n");
            IRepository<Customer> customerRepository =
              new Repository<Customer>();
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };
            customerRepository.Add(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nEnd program - no logging\r\n***");
            Console.ReadLine();
        }

        private static void OneDecoratorNoProxy()
        {
            Console.WriteLine("***\r\n Begin program - logging with decorator\r\n");
            IRepository<Customer> customerRepository =
              new LoggerRepository<Customer>(new Repository<Customer>());
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };
            customerRepository.Add(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nEnd program - logging with decorator\r\n***");
            Console.ReadLine();
        }

        private static void TwoDecoratorsNoProxy()
        {
            Console.WriteLine("***\r\n Begin program - no logging\r\n");

            var customerRepository =
                RepositoryFactory.CreateRepositoryWithDecorator<Customer>();
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };
            customerRepository.Add(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nEnd program - no logging\r\n***");

            Console.ReadLine();
        }

        

        private static void NoDecoratorTwoProxies()
        {

            Console.WriteLine("***\r\n Begin program - logging with dynamic proxy\r\n");

            var customerRepository =
                RepositoryFactory.CreateRepositoryWithProxy<Customer>();
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };
            customerRepository.Add(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nEnd program - logging with dynamic proxy\r\n***");
            Console.ReadLine();
        }

    }
}
