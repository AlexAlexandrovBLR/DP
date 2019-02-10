using System.Collections.Generic;
using System.Web.Mvc;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Models
{
    public class RemoveBusStopViewModel:BusStopModelDto
    {
        public List<SelectListItem> BusStops { get; set; }
    }
}
