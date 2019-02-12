using System.Collections.Generic;
using System.Web.Mvc;
using BusStation.Common;
using BusStation.Services.Models;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Interfaces
{
    public  interface IAdministrationService
    {
        SaveBusStopsViewModel SaveBusStops(BusStopViewModel model);
        List<SelectListItem> GetAllBusStopsName();
        BusStopDetailsViewModel GetBusStopDetails(int id);
        OperationResult UpdateBusStop(BusStopDetailsViewModel model);
        OperationResult RemoveBusStop(BusStopDetailsViewModel model);
        OperationResult AddRoutes(List<RouteModelDto> routes);
        List<SelectListItem> GetAllRouteItems();
        UpdateRoteViewModel GetRouteDetalies(int id);
        OperationResult SaveChangesRoute(UpdateRoteViewModel model);
        OperationResult RemoveRoute(int routeId);
    }
}
