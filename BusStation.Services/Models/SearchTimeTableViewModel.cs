using System.ComponentModel;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Models
{
    public class SearchTimeTableViewModel: TimeTableModelDto
    {
        [DisplayName("Маршрут")]
        public string NameRoute { get; set; }
    }
}
