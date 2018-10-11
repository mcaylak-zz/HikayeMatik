using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanusYazilim.MachineWebUI.GlobalDb
{
    public class Advertisement
    {
        public int AdvertisementID { get; set; }
        public string ImagePath { get; set; }
        public string Owner { get; set; }
        public int Time { get; set; }
    }
}