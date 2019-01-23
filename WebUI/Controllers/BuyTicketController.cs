using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusStation.Services.Models;

namespace WebUI.Controllers
{
    public class BuyTicketController : Controller
    {
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
            return new EmptyResult();
        }
    }
}