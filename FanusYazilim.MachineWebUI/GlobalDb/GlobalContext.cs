using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FanusYazilim.MachineWebUI.GlobalDb
{
    public class GlobalContext:DbContext
    {
        public GlobalContext() : base("GlobalHikayeMatik")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Content> Contents { get; set; }

    }
}