using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using Microsoft.AspNet.Identity;

namespace WebUI.Controllers
{
    public class BuyTicketController : Controller
    {
        private readonly IBuyTicketService _buyTicketService;

        public BuyTicketController(IBuyTicketService buyTicketService)
        {
            _buyTicketService = buyTicketService;
        }


        [HttpPost]
        public ActionResult BuyTicket(TimeTableViewModel model)
        {
            var buyModel = new BuyTicketViewModel
            {
                Amount = model.Price * model.Quantity,
                ArrivalStop = model.ArrivalStop,
                DepartureDate = model.DepartureDate,
                DepartureStop = model.DepartureStop,
                TameTableId = model.TameTableId,
                RouteId = model.RouteId,
                Quantity = model.Quantity
            };

            return View(buyModel);
        }

        [HttpPost]
        public ActionResult Checkout(BuyTicketViewModel model)
        {
            
            var result = _buyTicketService.CheckoutTicket(model, User.Identity.Name);

            if (result.Successed)
            {
                return PartialView("_CheckoutFailed");
            }

            return Json(new
            {
                Error =
                "Неудалось провести операцию, так как запрашиваемое количество билетов превышает количество доступных!"
            });
        }
    }
}