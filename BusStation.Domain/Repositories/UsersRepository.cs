using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{
    public class UsersRepository:IGenericBaseService<User>
    {
        private readonly BusStationContext _busStationContext;

        public UsersRepository(BusStationContext busStationContext)
        {
            _busStationContext = busStationContext;
        }

        public OperationResult Add(User item)
        {
            try
            {
                _busStationContext.Users.Add(item);
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

        public OperationResult Delete(User item)
        {
            try
            {
                _busStationContext.Users.Remove(item);
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

        public IEnumerable<User> GetAll()
        {
            return _busStationContext.Users;
        }

        public User GetById(int id)
        {
            return _busStationContext.Users.Find(id);
        }

        public OperationResult Update(User item)
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
