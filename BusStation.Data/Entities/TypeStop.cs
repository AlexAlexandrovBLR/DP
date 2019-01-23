using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class TypeStop
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
    }
}
