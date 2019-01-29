using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusStation.Common;
using BusStation.Data.Context;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;

namespace BusStation.Domain.Repositories
{

    public class RolesRepository : IGenericBaseService<Role>
    {
        private readonly BusStationContext _busStationContext;

        public RolesRepository(BusStationContext busStationContext)
        {
            _busStationContext = busStationContext;
        }

        public OperationResult Add(Role item)
        {
            try
            {
                _busStationContext.Roles.Add(item);
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

        public OperationResult Delete(Role item)
        {
            try
            {
                _busStationContext.Roles.Remove(item);
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

        public IEnumerable<Role> GetAll()
        {
            return _busStationContext.Roles;
        }

        public Role GetById(int id)
        {
            return _busStationContext.Roles.Find(id);
        }

        public OperationResult Update(Role item)
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
