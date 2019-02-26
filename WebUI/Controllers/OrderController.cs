using BusStation.Services.Interfaces;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public ActionResult CurrentOrders()
        {
            var model = _orderService.GetCurrentOrder(User.Identity.Name);

            return View(model);
        }

        [HttpGet]
        public ActionResult HistoryOrders()
        {
            var model = _orderService.GetHistoryOrder(User.Identity.Name);

            return View(model);
        }
    }
}