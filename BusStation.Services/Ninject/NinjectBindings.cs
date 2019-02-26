using BusStation.Domain.DomainServices;
using BusStation.Domain.Interfaces;
using BusStation.Services.Interfaces;
using BusStation.Services.Services;
using Ninject.Modules;

namespace BusStation.Services.Ninject
{
    public class NinjectBindings:NinjectModule
    {
        private readonly string _connectionString;

        public NinjectBindings(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            //registration bindings
            Bind<IUnitOfWork>().To<UnitOfWorkService>().WithConstructorArgument(_connectionString);
            Bind<IGetRouteService>().To<GetRouteService>();
            Bind<ISearchService>().To<SearchServise>();
            Bind<IAccountService>().To<AccountService>();
            Bind<IAdministrationService>().To<AdministrationService>();
            Bind<IBuyTicketService>().To<BuyTicketService>();
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
