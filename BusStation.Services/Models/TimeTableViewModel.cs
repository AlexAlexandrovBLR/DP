using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class TimeTableViewModel
    {
        public int TameTableId { get; set; }
        public int RouteId { get; set; }
        [DisplayName("Откуда")]
        public string DepartureStop { get; set; }
        [DisplayName("Куда")]
        public string ArrivalStop { get; set; }
        [DisplayName("Дата и время")]
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public int Seats { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Стоимость")]
        public decimal Amount { get; set; }
        public int TypeStopId { get; set; }
    }
}
