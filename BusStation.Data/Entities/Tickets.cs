using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class Tickets
    {
        public Tickets()
        {
            StatusOrderses=new List<Orders>();
            IdOrderses=new List<Orders>();
            SurnameCustomerses=new List<Customers>();
            TicketPrices=new List<Flights>();
            FlightName =new List<Flights>();
        }
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public int PlaceNumber { get; set; }
        public ICollection<Orders> StatusOrderses { get; set; }
        public ICollection<Orders> IdOrderses { get; set; }
        public ICollection<Customers> SurnameCustomerses { get; set; }
        public ICollection<Flights> TicketPrices { get; set; }
        public ICollection<Flights> FlightName { get; set; }
    }
}
