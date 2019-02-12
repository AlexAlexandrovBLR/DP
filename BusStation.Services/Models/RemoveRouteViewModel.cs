using BusStation.Services.Models.Dto;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BusStation.Services.Models
{
    public class RemoveRouteViewModel:RouteModelDto
    {
        public List<SelectListItem> Routes { get; set; }
    }
}
