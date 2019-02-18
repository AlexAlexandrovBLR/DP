using System.Collections.Generic;
using System.Web.Mvc;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Models
{
    public class RemoveTimeTableViewModel : AddTimeTableModelDto
    {
        public List<SelectListItem> RoutesList { get; set; }

        public List<AddTimeTableModelDto> TimeTables { get; set; }=new List<AddTimeTableModelDto>{new AddTimeTableModelDto()};
    }
}
