using System;
using System.Runtime.Remoting.Messaging;
using BusStation.Common;
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
        private TimeTablesRepository _timeTablesRepository;
        private TypeStopsRepository _typeStopsRepository;
        private UsersRepository _usersRepository;
        private RolesRepository _rolesRepository;

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

        public IGenericBaseService<TimeTable> TimeTablesRepository =>
            _timeTablesRepository ?? new TimeTablesRepository(_busStationContext);

        public IGenericBaseService<TypeStop> TypeStopsRepository =>
            _typeStopsRepository ?? new TypeStopsRepository(_busStationContext);

        public IGenericBaseService<User> UsersRepository => 
            _usersRepository ?? new UsersRepository(_busStationContext);

        public BusStationContext Context => _busStationContext;

        public IGenericBaseService<Role> RolesRepository =>
            _rolesRepository ?? new RolesRepository(_busStationContext);
        

        public OperationResult Save()
        {
            try
            {
                _busStationContext.SaveChanges();
                return new OperationResult();
            }
            catch (Exception e)
            {
                return new OperationResult
                {
                    Successed = false,
                    Message = e.Message
                };
            }
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
