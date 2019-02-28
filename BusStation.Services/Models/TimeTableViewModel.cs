using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Поле обязательно!")]
        [Range(1, 1000)]
        public int Quantity { get; set; } = 1;
        [DisplayName("Стоимость")]
        public decimal Amount { get; set; }
        public int TypeStopId { get; set; }
    }
}
