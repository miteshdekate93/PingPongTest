using PingPong4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PingPong4.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(): base("PlayerDatabase")
        {

        }
        public DbSet<Player> players { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}