using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanusYazilim.MachineWebUI.GlobalDb
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid SecurityGuid { get; set; }
    }
}