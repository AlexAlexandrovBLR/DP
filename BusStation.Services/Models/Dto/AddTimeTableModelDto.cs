using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusStation.Services.Models.Dto
{
    public class AddTimeTableModelDto
    {
        public int TimeTableId { get; set; }
        [DisplayName("Маршрут")]
        public int RouteId { get; set; }

        [Required]
        [DisplayName("Дата")]
        public DateTime DepartureDate { get; set; }

        [Required]
        [DisplayName("Время")]
        public TimeSpan DepartureTime { get; set; }


    }
}
