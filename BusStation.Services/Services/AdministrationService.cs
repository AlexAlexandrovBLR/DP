using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusStation.Common;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;
using BusStation.Services.Enums;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Services
{
    public class AdministrationService: IAdministrationService
    {
        #region Filds and ctors

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetRouteService _getRouteService;

        public AdministrationService(IUnitOfWork unitOfWork, IGetRouteService getRouteService)
        {
            _unitOfWork = unitOfWork;
            _getRouteService = getRouteService;
        }

        #endregion

        #region Public methods

        public SaveBusStopsViewModel SaveBusStops(BusStopViewModel model)
        {
            SaveBusStopsViewModel result = new SaveBusStopsViewModel();

            try
            {
                foreach (var item in model.BusStops)
                {
                    if (CheckBusStop(item.Name))
                    {
                        _unitOfWork.BusStopsRepository.Add(new BusStop
                        {
                            Description = item.Description,
                            Longitude = item.Longitude,
                            Latitude = item.Latitude,
                            Name = item.Name
                        });

                        result.SuccessSaved.Add(item.Name);
                    }
                    else
                    {
                        result.FailSaved.Add(item.Name);
                    }
                }

                _unitOfWork.Save();

                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public List<SelectListItem> GetAllBusStopsName()
        {
            var result = _unitOfWork.BusStopsRepository.GetAll().Select(s => new SelectListItem
            {
                Selected = false,
                Text = s.Name,
                Value = s.Id.ToString()
            });

            return result.ToList();
        }

        public BusStopDetailsViewModel GetBusStopDetails(int id)
        {
            BusStopDetailsViewModel model =new BusStopDetailsViewModel();

            var result = _unitOfWork.BusStopsRepository.GetById(id);

            if (result != null)
            {
                model.Id = result.Id;
                model.Name = result.Name;
                model.Description = result.Description;
                model.Latitude = result.Latitude;
                model.Longitude = result.Longitude;
            }

            return model;
        }

        public OperationResult UpdateBusStop(BusStopDetailsViewModel model)
        {
            BusStop busStop = _unitOfWork.BusStopsRepository.GetById(model.Id);

            if (busStop!=null)
            {
                busStop.Name = model.Name;
                busStop.Description = model.Description;
                busStop.Latitude = model.Latitude;
                busStop.Longitude = model.Longitude;

                var result = _unitOfWork.BusStopsRepository.Update(busStop);

                if (result.Successed)
                {
                    return _unitOfWork.Save();
                }
            }

            return new OperationResult
            {
                Successed = false,
                Message = "При сохранении изменений произошла ошибка"
            };
        }

        public OperationResult RemoveBusStop(BusStopDetailsViewModel model)
        {
            BusStop busStop = _unitOfWork.BusStopsRepository.GetById(model.Id);

            if (busStop != null && CheckTimeTableForBusStop(busStop))
            {
                var result = _unitOfWork.BusStopsRepository.Delete(busStop);

                if (result.Successed)
                {
                    return _unitOfWork.Save();
                }
            }

            return new OperationResult
            {
                Successed = false,
                Message = "При удвлении произошла ошибка. Остановочный пункт имеет активные маршруты."
            };
        }

        public OperationResult AddRoutes(List<RouteModelDto> routes)
        {
            bool isAdd = false;

            foreach (var route in routes)
            {
                var check = CheckRoute(route.StartId, route.StopId);

                if (check)
                {
                    isAdd = true;

                    var newRoute = new Route
                    {
                        NumberOfSeats = route.NumberOfSeats,
                        Price = route.Price,
                        RouteNumber = route.RouteNumber,
                        RouteStops = new List<RouteStop>
                        {
                            new RouteStop
                            {
                                BusStopId = route.StartId,
                                TypeStopId = (int) TypeStopEnum.Departure
                            },
                            new RouteStop
                            {
                                BusStopId = route.StopId,
                                TypeStopId = (int) TypeStopEnum.Arrival
                            }
                        }
                    };

                    _unitOfWork.RoutesRepository.Add(newRoute);
                }
            }

            if (isAdd)
            {
                return _unitOfWork.Save();
            }

            return new OperationResult
            {
                Successed = false,
                Message = "При добавлении маршрута произошла ошибка или маршруты уже существуют"
            };
        }

        public List<SelectListItem> GetAllRouteItems()
        {
            var result = _getRouteService.GetAllRoutes();

            var items = result.Select(s => new SelectListItem
            {
                Text = $"{s.DepartureBusStopName} - {s.ArrivalBusStopName}",
                Value = s.RouteId.ToString()
            });

            return items.ToList();
        }

        public UpdateRoteViewModel GetRouteDetalies(int id)
        {
            UpdateRoteViewModel result=new UpdateRoteViewModel();

            var stopsName = _getRouteService.GetStopsNames(id);

            var route = _unitOfWork.RoutesRepository.GetById(id);

            if (stopsName.Any() && route != null)
            {
                result.RouteId = route.Id;
                result.StartName = stopsName.FirstOrDefault(f => f.TypeStop == TypeStopEnum.Departure)?.Name;
                result.StopName = stopsName.FirstOrDefault(f => f.TypeStop == TypeStopEnum.Arrival)?.Name;
                result.RouteNumber = route.RouteNumber;
                result.NumberOfSeats = route.NumberOfSeats;
                result.Price = route.Price;
            }

            return result;
        }

        public OperationResult SaveChangesRoute(UpdateRoteViewModel model)
        {
            var route = _unitOfWork.RoutesRepository.GetById(model.RouteId);

            if (route!=null)
            {
                route.NumberOfSeats = model.NumberOfSeats;
                route.Price = model.Price;
                route.RouteNumber = model.RouteNumber;

                var updateResult = _unitOfWork.RoutesRepository.Update(route);

                if (updateResult.Successed)
                {
                    return _unitOfWork.Save();
                }
            }

            return new OperationResult
            {
                Successed = false,
                Message = "При изменении маршрута произошла ошибка"
            };
        }

        public OperationResult RemoveRoute(int routeId)
        {
            Route route = _unitOfWork.RoutesRepository.GetById(routeId);

            if (route != null && CheckTimeTableForRoute(route))
            {
                var result = _unitOfWork.RoutesRepository.Delete(route);

                if (result.Successed)
                {
                    return _unitOfWork.Save();
                }
            }

            return new OperationResult
            {
                Successed = false,
                Message = "При удвлении произошла ошибка. Маршрут имеет активное расписание."
            };
        }

        public OperationResult AddTimeTables(List<AddTimeTableModelDto> model)
        {
            bool isAdded = false;
            foreach (var item in model)
            {
                if (CheckTimeTable(item))
                {
                    isAdded = true;

                    TimeTable timeTable = new TimeTable
                    {
                        RouteId = item.RouteId,
                        Departure = item.DepartureDate + item.DepartureTime,
                        Arrival = item.DepartureDate + item.DepartureTime
                    };

                    _unitOfWork.TimeTablesRepository.Add(timeTable);
                }
            }
            if (isAdded)
            {
                return _unitOfWork.Save();
            }

            return new OperationResult
            {
                Successed = false,
                Message = "Произошла ошибка сохранеия или все введенные данные уже существую."
            };
        }

        public List<SearchTimeTableViewModel> GetOldTimeTablesByRoute(int routeId)
        {
            string name = GetStringNameRoute(routeId);

            var timeTables = _unitOfWork.TimeTablesRepository.GetAll()
                .Where(w => w.RouteId == routeId && w.Departure <= DateTime.Now.AddDays(-1))
                .Select(s =>
                new SearchTimeTableViewModel
                {
                    TameTableId = s.Id,
                    DepartureDate = s.Departure,
                    NameRoute = name
                });

            return timeTables.ToList();
        }

        public OperationResult RemoveTimeTableItem(int id)
        {
            var timeTable = _unitOfWork.TimeTablesRepository.GetById(id);

            if (timeTable != null)
            {
                _unitOfWork.TimeTablesRepository.Delete(timeTable);

                return _unitOfWork.Save();
            }

            return new OperationResult
            {
                Successed = false
            };
        }

        public OperationResult RemoveAllTimeTables(List<int> ids)
        {
            if (ids != null && ids.Any())
            {
                foreach (var id in ids)
                {
                    var timeTable = _unitOfWork.TimeTablesRepository.GetById(id);

                    if (timeTable != null)
                    {
                        _unitOfWork.TimeTablesRepository.Delete(timeTable);
                    }
                }

                return _unitOfWork.Save();
            }

            return new OperationResult
            {
                Successed = false
            };
        }
        
        #endregion



        #region Private methods

        private string GetStringNameRoute(int routeId)
        {
            var stopsName = _getRouteService.GetStopsNames(routeId);

            if (stopsName != null)
            {
                return
                    $"{stopsName.FirstOrDefault(f => f.TypeStop == TypeStopEnum.Departure)?.Name} - {stopsName.FirstOrDefault(f => f.TypeStop == TypeStopEnum.Arrival)?.Name}";
            }

            return string.Empty;
        }

        private bool CheckTimeTable(AddTimeTableModelDto timeTable)
        {
            var result = _unitOfWork.TimeTablesRepository.GetAll().FirstOrDefault(f =>
                f.RouteId == timeTable.RouteId && f.Departure == timeTable.DepartureDate + timeTable.DepartureTime);

            return result == null;
        }

        private bool CheckRoute(int startId, int stopId)
        {
            if (startId == stopId)
            {
                return false;
            }

            var start = _unitOfWork.RouteStopssRepository.GetAll().FirstOrDefault(f => f.BusStopId == startId && f.TypeStopId == (int)TypeStopEnum.Departure);
            var stop = _unitOfWork.RouteStopssRepository.GetAll().FirstOrDefault(f => f.BusStopId == stopId && f.TypeStopId == (int)TypeStopEnum.Arrival);

            if (start != null && stop != null)
            {
                return start.RouteId != stop.RouteId;
            }

            return true;
        }

        private bool CheckBusStop(string name)
        {
            var item = _unitOfWork.BusStopsRepository.GetAll().FirstOrDefault(f => f.Name == name);

            return item == null;
        }

        private bool CheckTimeTableForBusStop(BusStop busStop)
        {
            return !busStop.RouteStops.Any(a => a.Route.TimeTables.Any());
        }

        private bool CheckTimeTableForRoute(Route route)
        {
            return !route.TimeTables.Any();
        }
        #endregion


    }
}
