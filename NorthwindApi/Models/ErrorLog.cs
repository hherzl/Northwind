using System;
using System.Collections.Generic;
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

        public DateTime Date { get; set; }

        public String User { get; set; }

        public String UrlReferrer { get; set; }

        public String Url { get; set; }

        public String Browser { get; set; }

        public String BrowserVersion { get; set; }

        public String Exception { get; set; }

        private List<String> m_validationMessages;

        public List<String> ValidationMessages
        {
            get
            {
                return m_validationMessages ?? (m_validationMessages = new List<String>());
            }
        }
    }

    public class ErrorLogMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ErrorLog>
    {
        public ErrorLogMap()
        {
            HasKey(p => p.ID);

            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class ErrorLogDbInitializer : CreateDatabaseIfNotExists<ErrorLogDbContext>
    {
        protected override void Seed(ErrorLogDbContext context)
        {
            base.Seed(context);
        }
    }

    public class ErrorLogDbContext : System.Data.Entity.DbContext
    {
        public ErrorLogDbContext()
            : base("ErrorLogConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new ErrorLogDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ErrorLogMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ErrorLog> ErrorLog { get; set; }

        public void AddErrorLog(ErrorLog entity)
        {
            ErrorLog.Add(entity);

            SaveChanges();
        }
    }
}
