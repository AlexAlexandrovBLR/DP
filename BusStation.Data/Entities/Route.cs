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
        public Route()
        {
            Orders=new List<Order>();
            RouteStops=new List<RouteStop>();
            TimeTables=new List<TimeTable>();
        }

        public int Id { get; set; }
        public int RouteNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<RouteStop> RouteStops { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }
    }
}
