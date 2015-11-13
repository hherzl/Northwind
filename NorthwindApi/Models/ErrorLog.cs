using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace NorthwindApi.Models
{
    public class ErrorLog
    {
        private List<String> m_validationMessages;

        public ErrorLog()
        {

        }

        public Int32? ID { get; set; }

        public DateTime Date { get; set; }

        public String User { get; set; }

        public String UrlReferrer { get; set; }

        public String Url { get; set; }

        public String Browser { get; set; }

        public String BrowserVersion { get; set; }

        public List<String> ValidationMessages
        {
            get
            {
                return m_validationMessages ?? (m_validationMessages = new List<String>());
            }
        }

        public String Exception { get; set; }
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
