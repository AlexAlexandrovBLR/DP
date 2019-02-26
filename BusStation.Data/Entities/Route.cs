using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public int RouteNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
        public virtual ICollection<TimeTable> TimeTables { get; set; } = new List<TimeTable>();
    }
}
