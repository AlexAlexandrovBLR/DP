using System.Collections.Generic;
using BusStation.Services.Models;

namespace BusStation.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetCurrentOrder(string userName);
        List<OrderViewModel> GetHistoryOrder(string userName);
    }
}
