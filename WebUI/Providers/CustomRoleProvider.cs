using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusStation.Data.Entities;
using BusStation.Domain.Interfaces;
using Ninject;

namespace WebUI.Providers
{
    public class CustomRoleProvider: RoleProvider
    {
        [Inject] public IUnitOfWork UnitOfWork { get; set; } = DependencyResolver.Current.GetService<IUnitOfWork>();
        //private readonly IUnitOfWork _unitOfWork;


        #region override Methods

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = { };
            User user = UnitOfWork.UsersRepository.GetAll().FirstOrDefault(u => u.Email == username);
            if (user != null)
            {
                Role useRole = UnitOfWork.RolesRepository.GetAll().FirstOrDefault(r => r.RoleId == user.RoleId);
                if (useRole != null)
                    return new[] { useRole.Name };
            }
            return roles;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            User user = UnitOfWork.UsersRepository.GetAll().FirstOrDefault(u => u.Email == username);
            if (user != null)
            {
                Role role = UnitOfWork.RolesRepository.GetAll().FirstOrDefault(r => r.RoleId == user.RoleId);
                if (role != null && role.Name == roleName)
                    return  true;
            }
            return false;
        }

        #endregion

        #region Not Implementation

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}