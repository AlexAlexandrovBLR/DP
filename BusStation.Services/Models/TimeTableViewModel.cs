using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class TimeTableViewModel
    {
        public int RouteId { get; set; }
        public string DepartureStop { get; set; }
        public string ArrivalStop { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public int Seats { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
