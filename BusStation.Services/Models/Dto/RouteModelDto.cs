using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusStation.Services.Models.Dto
{
    public class RouteModelDto
    {
        public int RouteId { get; set; }

        [Required]
        [DisplayName("Начальная остановка")]
        public int StartId { get; set; }

        [Required]
        [DisplayName("Конечная остановка")]
        public int StopId { get; set; }

        public string StartName { get; set; }

        public string StopName { get; set; }

        [DisplayName("Номер маршрута")]
        [Range(typeof(int),"0", "99999", ErrorMessage = "Поле должно быть положительным")]
        public int RouteNumber { get; set; }

        [DisplayName("Количество мест")]
        [Range(typeof(int), "1", "50", ErrorMessage = "Поле должно быть от 1 до 50")]
        public int NumberOfSeats { get; set; }

        [DisplayName("Стоимость")]
        [Range(typeof(decimal), "1", "99999", ErrorMessage = "Минимальное значение 1")]
        public decimal Price { get; set; }
    }
}
