using BusStation.Common;
using BusStation.Services.Models;

namespace BusStation.Services.Interfaces
{
    public interface IBuyTicketService
    {
        OperationResult CheckoutTicket(BuyTicketViewModel model, string userName);
    }
}
