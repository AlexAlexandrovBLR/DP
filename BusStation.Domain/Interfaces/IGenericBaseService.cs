using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Common;

namespace BusStation.Domain.Interfaces
{
    public interface IGenericBaseService<T> where T:class 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        OperationResult Update(T item);
        OperationResult Delete(T item);
        OperationResult Add(T item);        
    }
}
