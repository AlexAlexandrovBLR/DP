using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class TypeStopsRepository:IGenericBaseService<TypeStop>
    {
        private readonly BusStationContext _busStationContext;

        public TypeStopsRepository(BusStationContext busStationContext)
        {
            _busStationContext = busStationContext;
        }

        public OperationResult Add(TypeStop item)
        {
            try
            {
                _busStationContext.TypeStops.Add(item);
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

        public OperationResult Delete(TypeStop item)
        {
            try
            {
                _busStationContext.TypeStops.Remove(item);
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

        public IEnumerable<TypeStop> GetAll()
        {
            return _busStationContext.TypeStops;
        }

        public TypeStop GetById(int id)
        {
            return _busStationContext.TypeStops.Find(id);
        }

        public OperationResult Update(TypeStop item)
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
