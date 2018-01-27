using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YIS.GDPDataHandler.Data.Infrastructure;
using YIS.Web.Services;
using YIS.GDPDataHandler.Db;

namespace YIS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGDPDataService _gdpDataService;

        public HomeController(IGDPDataService gdpDataService)
        {
            _gdpDataService = gdpDataService;
        }
        public HomeController() { }

        // GET: Home
        public ActionResult Index()
        {
            //var gdpData = _gdpDataService.GenerateData();
            return View();
        }
    }
}