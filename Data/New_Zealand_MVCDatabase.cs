using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using New_Zealand_MVC.Models;

namespace New_Zealand_MVC.Data
{
    public class New_Zealand_MVCDatabase : DbContext
    {
        public New_Zealand_MVCDatabase (DbContextOptions<New_Zealand_MVCDatabase> options)
            : base(options)
        {
        }

        public DbSet<New_Zealand_MVC.Models.Customer> Customer { get; set; }

        public DbSet<New_Zealand_MVC.Models.Attraction> Attraction { get; set; }

        public DbSet<New_Zealand_MVC.Models.Event> Event { get; set; }

        public DbSet<New_Zealand_MVC.Models.Hotel> Famous_Hotel { get; set; }

        public DbSet<New_Zealand_MVC.Models.Booking> Booking { get; set; }
    }
}
