using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusStation.Services.Models.Dto
{
    public class BusStopModelDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Широта")]
        [Range(typeof(double), "51,26254", "56,03090", ErrorMessage = "Широта должна находится в диапазоне от 51.26254 до 56.03090")]
        public double Latitude { get; set; }
        [Required]
        [Range(typeof(double), "23,23243", "32,3420", ErrorMessage = "Долгота должна находится в диапазоне от 23.23243 до 32.3420")]
        [DisplayName("Долгота")]
        public double Longitude { get; set; }
    }
}
