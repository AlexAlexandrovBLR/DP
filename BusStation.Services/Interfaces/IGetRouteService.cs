using System.Collections.Generic;
using BusStation.Services.Models;
using BusStation.Services.Models.InputModels;

namespace BusStation.Services.Interfaces
{
    public interface IGetRouteService
    {
        List<CurrentRouteViewModel> GetAllRoutes();
        List<RouteStopsModel> GetStopsNames(int routeId);
    }
}
