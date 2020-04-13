using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<SysBlock> SysBlocks { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=appdb;Trusted_Connection=True;");
        }
    }
}
