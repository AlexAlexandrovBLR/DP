using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class OrdersRepository : IGenericBaseService<Order>
    {
        private readonly BusStationContext _busStationContext;

        public OrdersRepository(BusStationContext context)
        {
            _busStationContext = context;
        }

        public OperationResult Add(Order item)
        {
            try
            {
                _busStationContext.Orders.Add(item);
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

        public OperationResult Delete(Order item)
        {
            try
            {
                _busStationContext.Orders.Remove(item);
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

        public IEnumerable<Order> GetAll()
        {
            return _busStationContext.Orders;
        }

        public Order GetById(int id)
        {
            return _busStationContext.Orders.Find(id);
        }

        public OperationResult Update(Order item)
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
