using System;
using System.Collections.Generic;
using System.Linq;
using BusStation.Domain.Interfaces;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;

namespace BusStation.Services.Services
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<OrderViewModel> GetCurrentOrder(string userName)
        {
            var user = _unitOfWork.UsersRepository.GetAll().FirstOrDefault(f => f.Email == userName);

            var orders = user?.Orders.Where(w=>w.DepartureDate >= DateTime.Now);

            return orders?.Select(s => new OrderViewModel
            {
                DepartureDate = s.DepartureDate,
                Description = s.Description,
                OperationDate = s.OperationDate
            }).ToList();
        }

        public List<OrderViewModel> GetHistoryOrder(string userName)
        {
            var user = _unitOfWork.UsersRepository.GetAll().FirstOrDefault(f => f.Email == userName);

            var orders = user?.Orders.Where(w => w.DepartureDate < DateTime.Now);

            return orders?.Select(s => new OrderViewModel
            {
                DepartureDate = s.DepartureDate,
                Description = s.Description,
                OperationDate = s.OperationDate
            }).ToList();
        }
    }
}
