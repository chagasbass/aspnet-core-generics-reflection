using GenericsAndReflections.App.Classes;
using GenericsAndReflections.App.Interfaces;
using Xunit;

namespace GenericsAndReflections.Testes
{
    public class IocTests
    {
        [Fact]
        public void DeveResolverTiposSimples()
        {
            var ioc = new MeuContainer();
            
            ioc.For<ILogger>().Use<ConsoleLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.Equal(typeof(ConsoleLogger), logger.GetType());

        }

        [Fact]
        public void DeveResolverTiposComConstrutorParametrizados()
        {
            var ioc = new MeuContainer();

            ioc.For<ILogger>().Use<ConsoleLogger>();
            ioc.For<IRepository<Cliente>>().Use<Repository<Cliente>>();

            var repository = ioc.Resolve<IRepository<Cliente>>();

            Assert.Equal(typeof(Repository<Cliente>), repository.GetType());

        }

        [Fact]
        public void DeveResolverTiposConcretos()
        {
            var ioc = new MeuContainer();

            ioc.For<ILogger>().Use<ConsoleLogger>();
            ioc.For(typeof(IRepository<>)).Use(typeof(Repository<>));

            var servico = ioc.Resolve<ClienteService>();

            Assert.NotNull(servico);

        }
    }
}
