using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class BusStopsRepository : IGenericBaseService<BusStop>
    {
        private readonly BusStationContext _busStationContext;

        public BusStopsRepository(BusStationContext context)
        {
            _busStationContext = context;
        }

        public OperationResult Add(BusStop item)
        {
            try
            {
                _busStationContext.BusStops.Add(item);
                return new OperationResult {Successed = true};
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

        public OperationResult Delete(BusStop item)
        {
            try
            {
                _busStationContext.BusStops.Remove(item);
                return new OperationResult {Successed = true};
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

        public IEnumerable<BusStop> GetAll()
        {
            return _busStationContext.BusStops;
        }

        public BusStop GetById(int id)
        {
            return _busStationContext.BusStops.Find(id);
        }

        public OperationResult Update(BusStop item)
        {
            try
            {
                _busStationContext.Entry(item).State = EntityState.Modified;
                return new OperationResult {Successed = true};
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
