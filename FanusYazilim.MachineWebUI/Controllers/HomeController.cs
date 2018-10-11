using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanusYazilim.BusinessLayer;
using FanusYazilim.BusinessLayer.Concrete.Mail;
using FanusYazilim.BusinessLayer.Concrete.Managers;
using FanusYazilim.BusinessLayer.Concrete.Printer;
using FanusYazilim.Entities;
using FanusYazilim.MachineWebUI.GlobalDb;

namespace FanusYazilim.MachineWebUI.Controllers
{
    public class HomeController : Controller
    {
        CategoryManager _category = new CategoryManager();
        ContentManager _content = new ContentManager();
        AdvertisementManager _advertisement = new AdvertisementManager();

        private ContentManager _ContentRepo = new ContentManager();

        // GET: Home
        public ActionResult Home()
        {

            List<Entities.Category> _categoryList = new List<Entities.Category>();
            _categoryList = _category.AllList();
            return View(_categoryList);

        }
        public ActionResult Content(int id)
        {
            IList<Entities.Content> contents = _ContentRepo.QueryDataList(r=> r.CategoryID == id);
            return View(contents);
        }
        public ActionResult Advertisement(int id)
        {
            Print.Printer(id);
            IList<Entities.Advertisement> advertisements = _advertisement.AllList();
            return View(advertisements);
        }
      
        public ActionResult Update()
        {
            return View();      
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            GlobalTransaction transaction = new GlobalTransaction();
            if (transaction.InternetKontrol())
            {
                
                if (id != null)
                {
                    transaction.Update(id.Value);
                    ViewBag.message = "Guncelleme İşlemi Tamamlandı";
                }
                
                
                return View(); ;
            }
            else
            {
                ViewBag.message = "İnternet Bağlantınız yok";
                return View();
            }
            
        }
        
    }
}