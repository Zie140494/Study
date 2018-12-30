using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumericWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["FIO"] = "Vasya";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MPif()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}