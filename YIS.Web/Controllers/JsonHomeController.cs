using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YIS.Web.Services;

namespace YIS.Web.Controllers
{
    public class JsonHomeController : Controller
    {
        private readonly IGDPChartService _gdpChartService;

        public JsonHomeController(IGDPChartService gdpChartService)
        {
            _gdpChartService = gdpChartService;
        }
        // GET: JsonHome
        //[AcceptVerbs(HttpVerbs.Post)]
        //[HttpGet]
        //public JsonResult GetGDPChartModel()
        //{
        //    var model = new
        //    {
        //        Foo = "Bar",
        //    };
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult GetGDPChartModel()
        {
            var model =
                _gdpChartService.GetChartModel();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}