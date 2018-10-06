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
            Category c1 = new Category()
            {
                Name = "Aşk"
            };
            Category c2 = new Category()
            {
                Name = "Masal"
            };
            Category c3 = new Category()
            {
                Name = "Fıkra"
            };

            _category.Insert(c1);
            _category.Insert(c3);
            _category.Insert(c2);

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