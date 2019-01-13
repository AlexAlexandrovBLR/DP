using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusStation.Services.Interfaces;

namespace WebUI.Controllers
{
    public class RouteController : Controller
    {
        private readonly IGetRouteService _getRouteService;

        public RouteController(IGetRouteService getRouteService)
        {
            _getRouteService = getRouteService;
        }

        [HttpPost]
        public ActionResult GetRoutes()
        {
            var result = _getRouteService.GetAllRoutes();
            return Json(result);
        }
    }
}