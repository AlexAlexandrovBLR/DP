using System;
using System.ComponentModel;

namespace BusStation.Services.Models.Dto
{
    public class AddTimeTableModelDto
    {
        [DisplayName("Маршрут")]
        public int RouteId { get; set; }

        [DisplayName("Дата")]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Время")]
        public TimeSpan DepartureTime { get; set; }


    }
}
