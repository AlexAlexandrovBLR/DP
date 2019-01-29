using BusStation.Data.Context;
using BusStation.Data.Entities;

namespace BusStation.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        BusStationContext Context { get; }

        IGenericBaseService<BusStop> BusStopsRepository { get;}
        IGenericBaseService<Order> OrdersRepository { get; }
        IGenericBaseService<Route> RoutesRepository { get; }
        IGenericBaseService<RouteStop> RouteStopssRepository { get; }
        IGenericBaseService<StatusOrder> StatusOrdersRepository { get; }
        IGenericBaseService<TimeTable> TimeTablesRepository { get; }
        IGenericBaseService<TypeStop> TypeStopsRepository { get; }
        IGenericBaseService<User> UsersRepository { get; }
        IGenericBaseService<Role> RolesRepository { get; }

        void Save();
    }
}
