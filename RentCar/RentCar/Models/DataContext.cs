using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RentCar.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("RentCar") { }

        public DbSet<CarPrice> CarPrices { get; set; }

        public DbSet<DriverPrice> DriverPrices { get; set; }
    }
}