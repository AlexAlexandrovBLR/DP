using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class StatusOrdersRepository:IGenericBaseService<StatusOrder>
    {
        private readonly BusStationContext _busStationContext;

        public StatusOrdersRepository(BusStationContext context)
        {
            _busStationContext = context;
        }

        public OperationResult Add(StatusOrder item)
        {
            try
            {
                _busStationContext.StatusOrders.Add(item);
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

        public OperationResult Delete(StatusOrder item)
        {
            try
            {
                _busStationContext.StatusOrders.Remove(item);
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

        public IEnumerable<StatusOrder> GetAll()
        {
            return _busStationContext.StatusOrders;
        }

        public StatusOrder GetById(int id)
        {
            return _busStationContext.StatusOrders.Find(id);
        }

        public OperationResult Update(StatusOrder item)
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
