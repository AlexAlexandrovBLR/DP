using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;

namespace BusStation.Services.Services
{
    public class AdministrationService: IAdministrationService
    {
        #region Filds and ctors

        private readonly IUnitOfWork _unitOfWork;

        public AdministrationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        #endregion



        #region Private methods

        private bool CheckBusStop(string name)
        {
            var item = _unitOfWork.BusStopsRepository.GetAll().FirstOrDefault(f => f.Name == name);

            return item == null;
        }

        #endregion


    }
}
