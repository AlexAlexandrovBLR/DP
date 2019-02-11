﻿using System;
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

            if (busStop != null)
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
                Message = "При удвлении произошла ошибка"
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

        #endregion



        #region Private methods

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

        #endregion


    }
}