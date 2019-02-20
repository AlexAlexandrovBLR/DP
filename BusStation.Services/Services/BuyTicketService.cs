using BusStation.Common;
using BusStation.Domain.Interfaces;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;

namespace BusStation.Services.Services
{
    public class BuyTicketService: IBuyTicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region ctor

        public BuyTicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion


        #region Public Methods

        public OperationResult CheckoutTicket(BuyTicketViewModel model)
        {
            if (CheckAvailability(model.TameTableId, model.Quantity))
            {
                var timeTable = _unitOfWork.TimeTablesRepository.GetById(model.TameTableId);

                if (timeTable!=null)
                {
                    timeTable.Seats = timeTable.Seats - model.Quantity;

                    if (timeTable.Seats >= 0)
                    {
                        return _unitOfWork.Save();
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

        #endregion
    }
}
