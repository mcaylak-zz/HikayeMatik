using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanusYazilim.BusinessLayer;
using FanusYazilim.BusinessLayer.Concrete.Mail;
using FanusYazilim.BusinessLayer.Concrete.Managers;
using FanusYazilim.Entities;


namespace FanusYazilim.MachineWebUI.Controllers
{
    public class HomeController : Controller
    {
        CategoryManager _category = new CategoryManager();
        
        // GET: Home
        public ActionResult Home()
        {
            List<Category> _categoryList = new List<Category>();
            _categoryList = _category.AllList();
            return View(_categoryList);
        }
        public ActionResult Content()
        {
            return View();
        }
    }
}