using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Services.Models;
using BusStation.Services.Models.InputModels;

namespace BusStation.Services.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<TimeTableViewModel> GetSearchResult(SearchRouteFilterModel filter);
    }
}
