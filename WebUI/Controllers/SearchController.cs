using System.Web.Mvc;
using BusStation.Services.Models.InputModels;

namespace WebUI.Controllers
{
    public class SearchController : Controller
    {

        public ActionResult Index()
        {
            var model=new SearchRouteFilterModel();
            return PartialView("SearchRouteForm", model);
        }
        
        public ActionResult Search(SearchRouteFilterModel filter)
        {
            return View();
        }
    }
}