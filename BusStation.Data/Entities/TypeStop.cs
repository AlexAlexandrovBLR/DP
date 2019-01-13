using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class TypeStop
    {
        public TypeStop()
        {
            RouteStops=new List<RouteStop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RouteStop> RouteStops { get; set; }
    }
}
