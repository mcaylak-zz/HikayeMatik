using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanusYazilim.BusinessLayer.Concrete.Managers;
using FanusYazilim.Entities;

namespace FanusYazilim.BusinessLayer.Concrete.Printer
{
    public static class Print
    {
        private static string Description;
        public static void Printer(int id)
        {
            ContentManager ContentManager = new ContentManager();
            Content _content = ContentManager.Find(x=>x.ContentID==id);
            _content.PrintLength++;
            Description = _content.Description;
            // PrintDocument nesnemizin tanimlamasi gerceklesiyor.
            PrintDocument pDoc = new PrintDocument();

            // Print event'i yaratiliyor.
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPage);
        }
        private static void pDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
            // Pixel degil Milimetre kullanicahiz
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            // Bu sekilde sabit bir printer'a yonlendire biliriz
            e.PageSettings.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";

            // yazdirmada kullanilacak bir font olusturalim.
            Font aFont = new System.Drawing.Font("Arial", 11);

            // stringi pDoc nesnemize yazdiralim.
            // string olarak icerigimizi verdik.
            // renk olarak brushes.black verdik ve X,Y olarak noktalarimizi belirttik.
            // ben genelde point kullanmaktan yana degilimdir gerci
            // bu yuzden tanimlamayi pointsiz yapalim.

            e.Graphics.DrawString(Description, aFont, Brushes.Black, 10f, 10f);
        }
    }
}
