using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models.Dto
{
    public class TimeTableModelDto
    {
        public int TameTableId { get; set; }
        public int RouteId { get; set; }
        public string NameStop { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public int Seats { get; set; }
        public int TypeStopId { get; set; }
    }
}
