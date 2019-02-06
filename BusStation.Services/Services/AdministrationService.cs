using System;
using System.Collections.Generic;
using System.Linq;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;

namespace BusStation.Services.Services
{
    public class AdministrationService: IAdministrationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdministrationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SaveBusStopsViewModel SaveBusStops(BusStopViewModel model)
        {
            SaveBusStopsViewModel result=new SaveBusStopsViewModel();

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

        private bool CheckBusStop(string name)
        {
            var item = _unitOfWork.BusStopsRepository.GetAll().FirstOrDefault(f => f.Name == name);

            return item == null;
        }
    }
}
