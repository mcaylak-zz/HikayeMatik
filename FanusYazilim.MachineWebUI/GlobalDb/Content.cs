using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanusYazilim.MachineWebUI.GlobalDb
{
    public class Content
    {
        public int ContentID { get; set; }
        public string Description { get; set; }
        public int DisplayLength { get; set; }
        public int PrintLength { get; set; }
        public virtual int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}