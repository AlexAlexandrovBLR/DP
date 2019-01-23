using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class BusStop
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public  string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude{ get; set; }

        public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
    }
}
