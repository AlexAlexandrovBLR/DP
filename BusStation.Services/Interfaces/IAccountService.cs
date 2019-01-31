using BusStation.Common;
using BusStation.Services.Models;

namespace BusStation.Services.Interfaces
{
    public interface IAccountService
    {
        bool CheckUser(string userEmail);
        bool RegisterNewUser(RegisterViewModel model);
        string GetHashedPassword(LoginViewModel model);
        UserViewModel GetUserInfo(string userName);
        OperationResult SaveUserInfo(UserViewModel model);
    }
}
