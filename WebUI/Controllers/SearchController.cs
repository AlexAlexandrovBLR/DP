using System.Linq;
using System.Web.Mvc;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using BusStation.Services.Models.InputModels;

namespace WebUI.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        public int PageSize = 4;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public ActionResult Index()
        {
            var model=new SearchRouteFilterModel();
            return PartialView("SearchRouteForm", model);
        }
        
        public ActionResult Search(SearchRouteFilterModel filter, int page = 1)
        {
            var res=_searchService.GetSearchResult(filter);

            ListTimeTableViewModel model = res != null
                ? new ListTimeTableViewModel
                {
                    TimeTableViewModels = res
                        .OrderBy(p => p.TameTableId)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = res.Count()
                    }
                }
                : new ListTimeTableViewModel();

            return View(model);
        }
    }
}