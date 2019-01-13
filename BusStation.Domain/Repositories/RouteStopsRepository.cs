using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class RouteStopsRepository : IGenericBaseService<RouteStop>
    {
        private readonly BusStationContext _busStationContext;

        public RouteStopsRepository(BusStationContext context)
        {
            _busStationContext = context;
        }

        public OperationResult Add(RouteStop item)
        {
            try
            {
                _busStationContext.RouteStops.Add(item);
                return new OperationResult { Successed = true };
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

        public OperationResult Delete(RouteStop item)
        {
            try
            {
                _busStationContext.RouteStops.Remove(item);
                return new OperationResult { Successed = true };
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

        public IEnumerable<RouteStop> GetAll()
        {
            return _busStationContext.RouteStops;
        }

        public RouteStop GetById(int id)
        {
            return _busStationContext.RouteStops.Find(id);
        }

        public OperationResult Update(RouteStop item)
        {
            try
            {
                _busStationContext.Entry(item).State = EntityState.Modified;
                return new OperationResult { Successed = true };
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
    }
}
