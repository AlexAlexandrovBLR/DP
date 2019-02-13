using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using BusStation.Services.Models.Dto;

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

        [HttpPost]
        public ActionResult SaveChangeBusStop(BusStopDetailsViewModel model)
        {
            var result = _administrationService.UpdateBusStop(model);

            return Json(result);
        }

        [HttpGet]
        public ActionResult RemoveBusStop()
        {
            var model = new RemoveBusStopViewModel
            {
                BusStops = _administrationService.GetAllBusStopsName()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult RemoveBusStop(BusStopDetailsViewModel model)
        {
            var result = _administrationService.RemoveBusStop(model);

            return Json(result);
        }

        [HttpGet]
        public ActionResult AddRoute()
        {
            RouteViewModel model = new RouteViewModel
            {
                Routes = _administrationService.GetAllBusStopsName()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddRoute(RouteViewModel model)
        {
            var result = _administrationService.AddRoutes(model.RouteModels);

            return Json(result);
        }

        [HttpGet]
        public ActionResult UpdateRoutes()
        {
            var model = new UpdateRoteViewModel()
            {
                Routes = _administrationService.GetAllRouteItems()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GetBusRouteDetails(int id)
        {
            var result = _administrationService.GetRouteDetalies(id);

            return Json(result);
        }

        [HttpPost]
        public ActionResult SaveChangesRoute(UpdateRoteViewModel model)
        {
            var result = _administrationService.SaveChangesRoute(model);

            return Json(result);
        }

        [HttpGet]
        public ActionResult RemoveRoute()
        {
            var model = new RemoveRouteViewModel()
            {
                Routes = _administrationService.GetAllRouteItems()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult RemoveRoute(RemoveRouteViewModel model)
        {
            var result = _administrationService.RemoveRoute(model.RouteId);

            return Json(result);
        }

        [HttpGet]
        public ActionResult AddTimeTables()
        {
            var model = new AddTimeTableViewModel
            {
                RoutesList = _administrationService.GetAllRouteItems()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddTimeTables(AddTimeTableViewModel model)
        {
            var result = _administrationService.AddTimeTables(model.TimeTables);
            return Json(result);
        }
    }
}