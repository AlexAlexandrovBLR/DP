using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;
using BusStation.Services.Enums;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using BusStation.Services.Models.Dto;
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
            List<TimeTableViewModel> searchList=new List<TimeTableViewModel>();
            var route = _unitOfWork.RoutesRepository.GetAll().ToList().FirstOrDefault(w => w.RouteStops.FirstOrDefault()?.BusStop.Name == filter.DepartureStation &&
                w.RouteStops.LastOrDefault()?.BusStop.Name == filter.ArrivalStation);

            if (route==null)
            {
                return null;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddRange(new []
            {
                new SqlParameter("@RouteId", route.Id),
                new SqlParameter("@DepartureTime", filter.DepartureDate)
            });

            string sqlQuery =
                @"select tt.Id as [TameTableId], r.Id as [RouteId], bs.[Name] as [NameStop], tt.Departure as [DepartureDate], r.Price as [Price], tt.Seats as [Seats], rs.TypeStopId as [TypeStopId]
                from TimeTables tt inner join [Routes] r on tt.RouteId=r.Id
                inner join RouteStops rs on rs.RouteId = r.Id
                inner join BusStops bs on rs.BusStopId=bs.Id
                where r.Id=@RouteId and tt.[Departure] >= @DepartureTime";

            var result = _unitOfWork.Context.Database.SqlQuery<TimeTableModelDto>(sqlQuery, parameters.Cast<object>().ToArray()).GroupBy(g=>g.TameTableId).ToList();

            if (result.Any())
            {
                foreach (var item in result)
                {
                    searchList.Add(new TimeTableViewModel
                    {
                        TameTableId = item.Key
                    });

                    foreach (var obj in item)
                    {

                        var checkElement = searchList.FirstOrDefault(f => f.TameTableId == item.Key);

                        if (checkElement != null)
                        {
                            int index = searchList.IndexOf(checkElement);
                            if (obj.TypeStopId == (int) TypeStopEnum.Departure)
                            {
                                searchList[index].DepartureDate = obj.DepartureDate;
                                searchList[index].DepartureStop = obj.NameStop;
                                searchList[index].RouteId = obj.RouteId;
                                searchList[index].Seats = obj.Seats;
                                searchList[index].Price = obj.Price;
                            }
                            else
                            {
                                searchList[index].ArrivalStop = obj.NameStop;
                            }
                        }
                        
                    }
                }
            }
            return searchList;
        }

        #region Private methods

        #endregion
    }
}
