using System.ComponentModel;

namespace BusStation.Services.Models.Dto
{
    public class BusStopModelDto
    {
        //public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Широта")]
        public double Latitude { get; set; }
        [DisplayName("Долгота")]
        public double Longitude { get; set; }
    }
}
