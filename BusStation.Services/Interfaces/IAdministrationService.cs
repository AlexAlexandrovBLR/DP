using System.Collections.Generic;
using System.Web.Mvc;
using BusStation.Services.Models;

namespace BusStation.Services.Interfaces
{
    public  interface IAdministrationService
    {
        SaveBusStopsViewModel SaveBusStops(BusStopViewModel model);
        List<SelectListItem> GetAllBusStopsName();
        BusStopDetailsViewModel GetBusStopDetails(int id);
    }
}
