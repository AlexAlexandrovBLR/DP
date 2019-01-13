using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Services.Models;

namespace BusStation.Services.Interfaces
{
    public interface IGetRouteService
    {
        List<CurrentRouteViewModel> GetAllRoutes();
    }
}
