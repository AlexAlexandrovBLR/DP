using BusStation.Common;
using BusStation.Services.Models;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Interfaces
{
    public interface IAccountService
    {
        bool CheckUser(string userEmail);
        bool RegisterNewUser(RegisterViewModel model);
        string GetHashedPassword(LoginViewModel model);
        UserViewModel GetUserInfo(string userName);
        OperationResult SaveUserInfo(UserViewModel model);
        OperationResult AddOrderToHistoryUser(OrderModelDto model, string userName);
    }
}
