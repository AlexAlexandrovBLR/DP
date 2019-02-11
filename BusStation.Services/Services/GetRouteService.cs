using System.Collections.Generic;
using System.Linq;
using BusStation.Domain.Interfaces;
using BusStation.Services.Enums;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using BusStation.Services.Models.InputModels;

namespace BusStation.Services.Services
{
    public class GetRouteService : IGetRouteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRouteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CurrentRouteViewModel> GetAllRoutes()
        {
            List<CurrentRouteViewModel> result=new List<CurrentRouteViewModel>();
            var routes = _unitOfWork.RouteStopssRepository.GetAll().GroupBy(g=>g.RouteId).ToList();
            routes.ForEach(x =>
            {
                var departure = x.FirstOrDefault(f => f.TypeStop.Name == TypeStopEnum.Departure.ToString());
                var arrival = x.FirstOrDefault(f => f.TypeStop.Name == TypeStopEnum.Arrival.ToString());
                if (departure != null && arrival != null)
                {
                    result.Add(new CurrentRouteViewModel
                    {
                        RouteId = departure.RouteId,
                        RouteNumber = departure.Route.RouteNumber,
                        DepartureBusStopName = departure.BusStop.Name,
                        CoordinatesDeparture = new CoordinatesModel
                        {
                            Latitude = departure.BusStop.Latitude,
                            Longitude = departure.BusStop.Longitude
                        },
                        ArrivalBusStopName = arrival.BusStop.Name,
                        CoordinatesArrival = new CoordinatesModel
                        {
                            Latitude = arrival.BusStop.Latitude,
                            Longitude = arrival.BusStop.Longitude
                        }
                    });
                }
            });
            return result;
        }

        public List<RouteStopsModel> GetStopsNames(int routeId)
        {
            List<RouteStopsModel> result=new List<RouteStopsModel>();

            var routes = _unitOfWork.RouteStopssRepository.GetAll().Where(w => w.RouteId == routeId).GroupBy(g => g.TypeStopId);

            foreach (var item in routes)
            {
                RouteStopsModel stop=new RouteStopsModel();

                if (item.Key == (int) TypeStopEnum.Departure)
                {
                    stop.TypeStop = TypeStopEnum.Departure;
                    stop.Name = item.FirstOrDefault()?.BusStop.Name;
                }
                else
                {
                    stop.TypeStop = TypeStopEnum.Arrival;
                    stop.Name = item.FirstOrDefault()?.BusStop.Name;
                }

                result.Add(stop);
            }

            return result;
        }
    }
}
