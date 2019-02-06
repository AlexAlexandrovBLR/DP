using System.Collections.Generic;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Models
{
    public class BusStopViewModel
    {
        public List<BusStopModelDto> BusStops { get; set; } = new List<BusStopModelDto>{new BusStopModelDto()};
    }
}
