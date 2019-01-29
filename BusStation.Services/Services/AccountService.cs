using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;
using BusStation.Services.Enums;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;

namespace BusStation.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckUser(string userEmail)
        {
            User user= _unitOfWork.UsersRepository.GetAll().FirstOrDefault(u => u.Email == userEmail);

            return user == null;
        }

        public bool RegisterNewUser(RegisterViewModel model)
        {
            User user = new User
            {
                Email = model.Email,
                Password = model.Password,
                Role = _unitOfWork.RolesRepository.GetById((int) RoleTypeEnum.User)
            };
            var addUser = _unitOfWork.UsersRepository.Add(user);

            _unitOfWork.Save();

            return addUser.Successed;
        }

        public string GetHashedPassword(LoginViewModel model)
        {
            string hashedPassword = _unitOfWork.UsersRepository.GetAll().FirstOrDefault(f => f.Email == model.Email)?.Password;

            return hashedPassword;
        }
    }
}
