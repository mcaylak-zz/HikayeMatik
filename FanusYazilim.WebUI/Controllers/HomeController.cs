using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FanusYazilim.WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        public ActionResult Advertisement()
        {
            return View();

        }
        public ActionResult AddAdvertisement()
        {
            return View();

        }
        public ActionResult Content()
        {
            return View();
        }
        public ActionResult Contents()
        {
            return View();
        }
        public ActionResult AddContent()
        {
            return View();
        }
        public ActionResult Statistics()
        {
            return View();
        }
    }
}