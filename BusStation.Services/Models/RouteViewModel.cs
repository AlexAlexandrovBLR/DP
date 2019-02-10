using System.Collections.Generic;
using System.Web.Mvc;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Models
{
    public class RouteViewModel
    {
        public List<SelectListItem> Routes { get; set; }
        public List<RouteModelDto> RouteModels { get; set; }=new List<RouteModelDto>{new RouteModelDto()};
    }
}
