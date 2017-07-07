using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CrudDemo.Models
{
    public class CrudContext : DbContext
    {
        public CrudContext(): base("name=CrudContext")
        {

        }
        public DbSet<CrudDemo.Models.Player> players { get; set; }
    }
}