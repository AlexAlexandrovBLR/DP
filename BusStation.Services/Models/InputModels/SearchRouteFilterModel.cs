using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusStation.Services.Models.InputModels
{
    public class SearchRouteFilterModel
    {
        [Required(ErrorMessage = "Поле обязательно!")]
        [DisplayName("Откуда:")]
        public string DepartureStation { get; set; }

        [Required(ErrorMessage = "Поле обязательно!")]
        [DisplayName("Куда:")]
        public string ArrivalStation { get; set; }

        [DisplayName("Дата:")]
        [Required(ErrorMessage = "Поле дата обязательно!")]
        public DateTime DepartureDate { get; set; }
    }
}
