using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TelefonDefteriCodeFirst.Models;

namespace TelefonDefteriCodeFirst.DataAccessLayer
{
    public class KayitTakipDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }

        public KayitTakipDBContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}