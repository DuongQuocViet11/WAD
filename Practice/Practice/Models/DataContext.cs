using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Practice.Models
{
    public class DataContext : DbContext
    {
        
            public DataContext() : base("Practice") { }

            public DbSet<Contact> Contacts { get; set; }

            
        
    }
}