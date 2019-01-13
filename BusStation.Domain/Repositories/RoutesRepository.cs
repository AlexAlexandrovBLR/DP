using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class RoutesRepository : IGenericBaseService<Route>
    {
        private readonly BusStationContext _busStationContext;

        public RoutesRepository(BusStationContext context)
        {
            _busStationContext = context;
        }

        public OperationResult Add(Route item)
        {
            try
            {
                _busStationContext.Routes.Add(item);
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

        public OperationResult Delete(Route item)
        {
            try
            {
                _busStationContext.Routes.Remove(item);
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

        public IEnumerable<Route> GetAll()
        {
            return _busStationContext.Routes;
        }

        public Route GetById(int id)
        {
            return _busStationContext.Routes.Find(id);
        }

        public OperationResult Update(Route item)
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
