using FanusYazilim.BusinessLayer.Concrete.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace FanusYazilim.MachineWebUI.GlobalDb
{
    public class GlobalTransaction
    {
        GlobalContext gDb = new GlobalContext();

        CategoryManager _category = new CategoryManager();
        ContentManager _content = new ContentManager();
        AdvertisementManager _advertisement = new AdvertisementManager();


        public GlobalTransaction()
        {
                            

        }
        public void Update(int control)
        {
            if (control == 1)
            {
                CategoryUpdate();
            }
            else if (control == 2)
            {
                ContentUpdate();
            }
            else if (control == 3)
            {
                AdvertisementUpdate();
            }
        }
        public bool InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        private void AdvertisementUpdate()
        {
            IList<Advertisement> NewAdvertisement = gDb.Advertisements.ToList();
            IList<Entities.Advertisement> OldAdvertisements= _advertisement.AllList();

            Entities.Advertisement insert = new Entities.Advertisement();

            for (int i = 0; i<OldAdvertisements.Count;i++)
            {
                _advertisement.Delete(OldAdvertisements[i]);
            }
            for (int i = 0; i < NewAdvertisement.Count; i++)
            {
                insert.ImagePath = NewAdvertisement[i].ImagePath;
                insert.Owner = NewAdvertisement[i].Owner;
                insert.Second = NewAdvertisement[i].Time;
                insert.ImagePath = DowloadPictureTwo(NewAdvertisement[i].ImagePath);
                _advertisement.Insert(insert);
            }
        }
        private void ContentUpdate()
        {
            IList<Content> NewContent = gDb.Contents.ToList();
            IList<Entities.Content> OldContent = _content.AllList();
            IList<Entities.Category> OldCategories = _category.AllList();

            Entities.Content insert = new Entities.Content();

            for (int i = 0; i < OldContent.Count; i++)
            {
                _content.Delete(OldContent[i]);
            }
            for (int i = 0; i < NewContent.Count; i++)
            {
                int id = NewContent[i].CategoryID;
                Category category = gDb.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
                Entities.Category name = _category.Find(x=>x.Name == category.Name);
                insert.CategoryID = name.CategoryID;
                insert.Description = NewContent[i].Description;
                               
                _content.Insert(insert);
            }
        }
        private void CategoryUpdate()
        {
            IList<Category> NewCategories = gDb.Categories.ToList();
            IList<Entities.Category> OldCategories = _category.AllList();

            List<Category> CleanList = new List<Category>();
            List<Entities.Category> DeleteList = new List<Entities.Category>();

            int control = 0;

            foreach (var item in NewCategories)
            {
                foreach (var i in OldCategories)
                {
                    if (i.Name == item.Name)
                    {
                        control++;
                    }
                   
                }
                if (control== 0)
                {
                    CleanList.Add(item);
                }
                control = 0;
            }
            foreach (var item in OldCategories)
            {
                foreach (var i in NewCategories)
                {
                    if (i.Name == item.Name)
                    {
                        control++;
                    }

                }
                if (control == 0)
                {
                    DeleteList.Add(item);
                }
                control = 0;
            }

            foreach (var item in DeleteList)
            {
                _category.Delete(item);
            }

            Entities.Category category;
                
            foreach (var item in CleanList)
            {
                category = new Entities.Category();
                category.CategoryImageUrl = DowloadPicture(item.CategoryImageUrl);
                category.Name = item.Name;
                _category.Insert(category);
            }

        }
        private string DowloadPicture(string path)
        {
            WebClient webClient = new WebClient();
            Random rnd = new Random();
            int number = rnd.Next(0, 1000);
            string yol = "C:/Users/muhammed/Source/Repos/Aytekin/FanusYazilim/FanusYazilim.MachineWebUI/Assest/CatImage/" + number + ".jpg";
            webClient.DownloadFile(path, yol);
            return "Assest/CatImage/"+ number + ".jpg";
        }
        private string DowloadPictureTwo(string path)
        {
            WebClient webClient = new WebClient();
            Random rnd = new Random();
            int number = rnd.Next(0, 1000);
            string yol = "C:/Users/muhammed/Source/Repos/Aytekin/FanusYazilim/FanusYazilim.MachineWebUI/Assest/AdverImage/" + number + ".jpg";
            webClient.DownloadFile(path, yol);
            return "/Assest/AdverImage/" + number + ".jpg";
        }
    }
}