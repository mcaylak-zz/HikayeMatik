using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FanusYazilim.DataAccessLayer.EntityFramework;

namespace FanusYazilim.DataAccessLayer.Databasenitializer
{
    public class Initializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //creating 
        }
    }
}
