using BusStation.Services.Enums;

namespace BusStation.Services.Models.InputModels
{
    public class RouteStopsModel
    {
        public TypeStopEnum TypeStop { get; set; }
        public string Name { get; set; }
    }
}
