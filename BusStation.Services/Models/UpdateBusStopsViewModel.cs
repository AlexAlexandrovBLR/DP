using System.Collections.Generic;
using System.Web.Mvc;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Models
{
    public class UpdateBusStopsViewModel:BusStopModelDto
    {
        public List<SelectListItem> BusStops { get; set; }
    }
}
