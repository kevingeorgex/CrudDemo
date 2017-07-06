using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CrudDemo.Models
{
    public class CrudContext : DbContext
    {
        public DbSet<CrudDemo.Models.Player> players { get; set; }
    }
}