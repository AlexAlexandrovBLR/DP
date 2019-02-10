using System.ComponentModel;

namespace BusStation.Services.Models.Dto
{
    public class RouteModelDto
    {
        [DisplayName("Начальная остановка")]
        public int StartId { get; set; }
        [DisplayName("Конечная остановка")]
        public int StopId { get; set; }
        [DisplayName("Номер маршрута")]
        public int RouteNumber { get; set; }
        [DisplayName("Количество мест")]
        public int NumberOfSeats { get; set; }
        [DisplayName("Стоимость")]
        public decimal Price { get; set; }
    }
}
