using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;

namespace WebUI.Controllers
{
    public class AdministrationController : Controller
    {

        private readonly IAdministrationService _administrationService;

        public AdministrationController(IAdministrationService administrationService)
        {
            _administrationService = administrationService;
        }

        [HttpGet]
        public ActionResult AddNewStops()
        {
            BusStopViewModel model=new BusStopViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddNewStops(BusStopViewModel model)
        {
            var result = _administrationService.SaveBusStops(model);


            return View("AddedBusStops", result);
        }

        [HttpGet]
        public ActionResult UpdateBusStops()
        {
            var model = new UpdateBusStopsViewModel
            {
                BusStops = _administrationService.GetAllBusStopsName()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GetBusStopDetails(int id)
        {
            var result = _administrationService.GetBusStopDetails(id);

            return Json(result);
        }

        public ActionResult SaveChangeBusStop(BusStopDetailsViewModel model)
        {
            return null;
        }

    }
}