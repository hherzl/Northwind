using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>, IEntityConfiguration
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");

            HasKey(p => new { p.EmployeeID });

            Property(p => p.EmployeeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.EmployeeID).HasColumnName("EmployeeID").HasColumnType("int").IsRequired();

            Property(p => p.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(40).IsRequired();

            Property(p => p.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(20).IsRequired();

            Property(p => p.Title).HasColumnName("Title").HasColumnType("nvarchar").HasMaxLength(60).IsOptional();

            Property(p => p.TitleOfCourtesy).HasColumnName("TitleOfCourtesy").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();

            Property(p => p.BirthDate).HasColumnName("BirthDate").HasColumnType("datetime").IsOptional();

            Property(p => p.HireDate).HasColumnName("HireDate").HasColumnType("datetime").IsOptional();

            Property(p => p.Address).HasColumnName("Address").HasColumnType("nvarchar").HasMaxLength(120).IsOptional();

            Property(p => p.City).HasColumnName("City").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.Region).HasColumnName("Region").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.PostalCode).HasColumnName("PostalCode").HasColumnType("nvarchar").HasMaxLength(20).IsOptional();

            Property(p => p.Country).HasColumnName("Country").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.HomePhone).HasColumnName("HomePhone").HasColumnType("nvarchar").HasMaxLength(48).IsOptional();

            Property(p => p.Extension).HasColumnName("Extension").HasColumnType("nvarchar").HasMaxLength(8).IsOptional();

            Property(p => p.Photo).HasColumnName("Photo").HasColumnType("image").IsOptional();

            Property(p => p.Notes).HasColumnName("Notes").HasColumnType("ntext").IsOptional();

            Property(p => p.ReportsTo).HasColumnName("ReportsTo").HasColumnType("int").IsOptional();

            Property(p => p.PhotoPath).HasColumnName("PhotoPath").HasColumnType("nvarchar").HasMaxLength(510).IsOptional();

            //HasOptional(p => p.FkEmployeesEmployees).WithMany(p => p.Employees).HasForeignKey(p => p.ReportsTo).WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
