using System;
using System.Linq;
using BusStation.Common;
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

        public UserViewModel GetUserInfo(string userName)
        {
            User user = _unitOfWork.UsersRepository.GetAll().FirstOrDefault(f=>f.Email==userName);
            if (user != null)
            {
                return new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleName = user.Role.Name,
                    Address = user.Address,
                    City = user.City,
                    ZipCode = user.ZipCode,
                    DateOfBirth = user.DateOfBirth,
                    Phone = user.Phone
                };
            }

            return null;
        }

        public OperationResult SaveUserInfo(UserViewModel model)
        {
            try
            {
                User user = _unitOfWork.UsersRepository.GetById(model.Id);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.City = model.City;
                user.ZipCode = model.ZipCode;
                user.DateOfBirth = model.DateOfBirth;
                user.Phone = model.Phone;
                OperationResult result=_unitOfWork.UsersRepository.Update(user);
                _unitOfWork.Save();

                return result;
            }
            catch (Exception e)
            {
                return new OperationResult
                {
                    Successed = false,
                    Message = e.Message
                };
            }
        }
    }
}
