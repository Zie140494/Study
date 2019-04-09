using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Search.Models
{
    public class TitleContext : DbContext
    {
        public DbSet<Title> Titles { get; set; }
    }
}
