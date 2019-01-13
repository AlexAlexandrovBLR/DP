using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusStation.Domain.Interfaces;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using BusStation.Services.Models.InputModels;

namespace BusStation.Services.Services
{
    public class SearchServise:ISearchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchServise(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TimeTableViewModel> GetSearchResult(SearchRouteFilterModel filter)
        {
            //var result = from repository in _unitOfWork.TimeTablesRepository.GetAll()
            //    where  repository.Route.RouteStops.FirstOrDefault(f=>f.TypeStop.Name=="Departure"&&f.BusStop.Name==filter.DepartureStation)
            return null;
        }
    }
}
