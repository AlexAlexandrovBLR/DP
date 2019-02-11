using System.Collections.Generic;
using System.Web.Mvc;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Models
{
    public class UpdateRoteViewModel:RouteModelDto
    {
        public List<SelectListItem> Routes { get; set; }
    }
}
