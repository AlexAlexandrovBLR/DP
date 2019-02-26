using System;
using System.Linq;
using BusStation.Common;
using BusStation.Domain.Interfaces;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using BusStation.Services.Models.Dto;

namespace BusStation.Services.Services
{
    public class BuyTicketService: IBuyTicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        #region ctor

        public BuyTicketService(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }

        #endregion


        #region Public Methods

        public OperationResult CheckoutTicket(BuyTicketViewModel model, string userName)
        {
            if (CheckAvailability(model.TameTableId, model.Quantity))
            {
                var timeTable = _unitOfWork.TimeTablesRepository.GetById(model.TameTableId);

                if (timeTable!=null)
                {
                    timeTable.Seats = timeTable.Seats - model.Quantity;

                    if (timeTable.Seats >= 0)
                    {
                        var result = _unitOfWork.Save();

                        if (result.Successed)
                        {
                            var order=GetOrderModel(model);
                            _accountService.AddOrderToHistoryUser(order, userName);

                            return result;
                        }
                    }
                }
            }

            return new OperationResult
            {
                Successed = false
            };
        }

        #endregion



        #region Private Methods

        private bool CheckAvailability(int id, int quantity)
        {
            var timeTable = _unitOfWork.TimeTablesRepository.GetById(id);

            return quantity <= timeTable?.Seats;
        }

        private OrderModelDto GetOrderModel(BuyTicketViewModel model)
        {
            OrderModelDto result = new OrderModelDto
            {
                DepartureDate = model.DepartureDate,
                Description =
                    $"{model.DepartureStop} - {model.ArrivalStop}, {model.DepartureDate:g}, в количестве {model.Quantity} шт.",
                OperationDate = DateTime.Now
            };

            return result;
        }

        #endregion
    }
}
