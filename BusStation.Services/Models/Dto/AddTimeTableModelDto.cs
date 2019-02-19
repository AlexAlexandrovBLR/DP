using System;
using System.ComponentModel;

namespace BusStation.Services.Models.Dto
{
    public class AddTimeTableModelDto
    {
        public int TimeTableId { get; set; }
        [DisplayName("Маршрут")]
        public int RouteId { get; set; }

        [DisplayName("Дата")]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Время")]
        public TimeSpan DepartureTime { get; set; }


    }
}
