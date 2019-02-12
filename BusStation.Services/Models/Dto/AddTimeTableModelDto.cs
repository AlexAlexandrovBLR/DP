using System;
using System.ComponentModel;

namespace BusStation.Services.Models.Dto
{
    public class AddTimeTableModelDto
    {
        [DisplayName("Маршрут")]
        public int RouteId { get; set; }

        [DisplayName("Дата и время")]
        public DateTime DepartureDate { get; set; }

    }
}
