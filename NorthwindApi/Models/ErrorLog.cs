using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace NorthwindApi.Models
{
    public class ErrorLog
    {
        public ErrorLog()
        {

        }

        public Int32? ID { get; set; }

        public String Message { get; set; }
    }

    public class ErrorLogDbContext : System.Data.Entity.DbContext
    {
        public ErrorLogDbContext()
            : base("ErrorLogConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<ErrorLog> ErrorLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLog>().HasKey(p => p.ID);

            modelBuilder.Entity<ErrorLog>().Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
