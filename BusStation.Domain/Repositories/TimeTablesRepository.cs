using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class TimeTablesRepository:IGenericBaseService<TimeTable>
    {
        private readonly BusStationContext _busStationContext;

        public TimeTablesRepository(BusStationContext context)
        {
            _busStationContext = context;
        }

        public OperationResult Add(TimeTable item)
        {
            try
            {
                _busStationContext.TimeTables.Add(item);
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

        public OperationResult Delete(TimeTable item)
        {
            try
            {
                _busStationContext.TimeTables.Remove(item);
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

        public IEnumerable<TimeTable> GetAll()
        {
            return _busStationContext.TimeTables;
        }

        public TimeTable GetById(int id)
        {
            return _busStationContext.TimeTables.Find(id);
        }

        public OperationResult Update(TimeTable item)
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
