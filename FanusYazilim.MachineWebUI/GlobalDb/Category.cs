using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanusYazilim.MachineWebUI.GlobalDb
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int DisplayLength { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public string CategoryImageUrl { get; set; }
    }
}