using System.Web.Mvc;
using BusStation.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}