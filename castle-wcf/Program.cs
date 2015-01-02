using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.TypedFactory;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using Component = Castle.MicroKernel.Registration.Component;

namespace ConsoleApplication7
{
    public interface IHelloService
    {
        string Hello();
    }

    public class HelloService : IHelloService
    {

        public string Hello()
        {
            return "Hello";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer()
                .AddFacility<WcfFacility>()
                .Register(
                    Component.For<IHelloService>().ImplementedBy<HelloService>());

            var service = new DefaultServiceHostFactory().CreateServiceHost(typeof(IHelloService).AssemblyQualifiedName, new Uri[0]);
            service.Open();

            Console.ReadKey();
        }
    }
}
