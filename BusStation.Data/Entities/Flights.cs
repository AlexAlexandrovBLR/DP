using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class Flights
    {
        public Flights()
        {
           Start= new List<BusStops>(); 
           Stop= new List<BusStops>();
        }
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int FlightNumber { get; set; }
        public string FlightName { get; set; }
        public  int NumberOfSeats { get; set; }
        public int TicketPrice { get; set; }
        public  ICollection<BusStops> Start { get; set; }
        public ICollection<BusStops> Stop { get; set; }
    }
}
