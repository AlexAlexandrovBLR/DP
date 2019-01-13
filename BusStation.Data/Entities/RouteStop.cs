using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class RouteStop
    {
        public int Id { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        [ForeignKey("BusStop")]
        public int BusStopId { get; set; }
        [ForeignKey("TypeStop")]
        public int TypeStopId { get; set; }

        public virtual Route Route { get; set; }
        public virtual BusStop BusStop { get; set; }
        public virtual TypeStop TypeStop { get; set; }
    }
}
