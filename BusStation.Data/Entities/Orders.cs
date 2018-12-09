using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class Orders
    {
        public Orders()
        {
            IdFlightses=new List<Flights>();
        }
        public int Id { get; set; }
        public  string Status { get; set; }
        public ICollection<Flights> IdFlightses { get; set; }
    }
}
