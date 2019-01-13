using System;
using System.Runtime.Remoting.Messaging;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;
using BusStation.Domain.Repositories;

namespace BusStation.Domain.DomainServices
{
    public class UnitOfWorkService : IUnitOfWork, IDisposable
    {
        private BusStopsRepository _busStopsRepository;
        private OrdersRepository _ordersRepository;
        private RouteStopsRepository _routeStopsRepository;
        private RoutesRepository _routesRepository;
        private StatusOrdersRepository _statusOrdersRepository;
        private TimeTablesRepository _timeTablesRepository;
        private TypeStopsRepository _typeStopsRepository;
        private UsersRepository _usersRepository;

        private readonly BusStationContext _busStationContext;

        public UnitOfWorkService(string connectionString)
        {
            _busStationContext=new BusStationContext(connectionString);
        }

        public IGenericBaseService<BusStop> BusStopsRepository =>
            _busStopsRepository ?? new BusStopsRepository(_busStationContext);

        public IGenericBaseService<Order> OrdersRepository =>
            _ordersRepository ?? new OrdersRepository(_busStationContext);

        public IGenericBaseService<Route> RoutesRepository =>
            _routesRepository ?? new RoutesRepository(_busStationContext);

        public IGenericBaseService<RouteStop> RouteStopssRepository =>
            _routeStopsRepository ?? new RouteStopsRepository(_busStationContext);

        public IGenericBaseService<StatusOrder> StatusOrdersRepository =>
            _statusOrdersRepository ?? new StatusOrdersRepository(_busStationContext);

        public IGenericBaseService<TimeTable> TimeTablesRepository =>
            _timeTablesRepository ?? new TimeTablesRepository(_busStationContext);

        public IGenericBaseService<TypeStop> TypeStopsRepository =>
            _typeStopsRepository ?? new TypeStopsRepository(_busStationContext);

        public IGenericBaseService<User> UsersRepository => 
            _usersRepository ?? new UsersRepository(_busStationContext);

        public void Save()
        {
            _busStationContext.SaveChanges();
        }

        //IDisposable


        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _busStationContext.Dispose();
                }

                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
