using System;
using System.ComponentModel;

namespace BusStation.Services.Models.Dto
{
    public class TimeTableModelDto
    {
        public int TameTableId { get; set; }
        public int RouteId { get; set; }
        public string NameStop { get; set; }
        [DisplayName("Дата и время")]
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public int Seats { get; set; }
        public int TypeStopId { get; set; }
    }
}
