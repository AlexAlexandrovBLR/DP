using BusStation.Services.Models;

namespace BusStation.Services.Interfaces
{
    public  interface IAdministrationService
    {
        SaveBusStopsViewModel SaveBusStops(BusStopViewModel model);
    }
}
