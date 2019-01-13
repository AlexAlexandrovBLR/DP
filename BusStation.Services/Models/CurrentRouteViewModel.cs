using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class CurrentRouteViewModel
    {
        public int RouteId { get; set; }
        public int RouteNumber { get; set; }
        public string DepartureBusStopName { get; set; }
        public CoordinatesModel CoordinatesDeparture { get; set; }
        public string ArrivalBusStopName { get; set; }
        public CoordinatesModel CoordinatesArrival { get; set; }
    }
}
