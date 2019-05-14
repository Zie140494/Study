namespace Smart_Search.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContriesModel1 : DbContext
    {
        public ContriesModel1()
            : base("name=ContriesModel1")
        {
        }

        public virtual DbSet<Contry> Contries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
