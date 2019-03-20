using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalAssingment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This page is for site description.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Group 9 contect Page.";

            return View();
        }
    }
}