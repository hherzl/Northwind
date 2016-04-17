using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class EmployeeMap : EntityTypeConfiguration<Employee>, IEntityConfiguration
    {
        public EmployeeMap()
        {
            ToTable("Employees");

            HasKey(p => new { p.EmployeeID });

            Property(p => p.EmployeeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.EmployeeID).HasColumnType("int").IsRequired();

            Property(p => p.LastName).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();

            Property(p => p.FirstName).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();

            Property(p => p.Title).HasColumnType("nvarchar").HasMaxLength(60).IsOptional();

            Property(p => p.TitleOfCourtesy).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();

            Property(p => p.BirthDate).HasColumnType("datetime").IsOptional();

            Property(p => p.HireDate).HasColumnType("datetime").IsOptional();

            Property(p => p.Address).HasColumnType("nvarchar").HasMaxLength(120).IsOptional();

            Property(p => p.City).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.Region).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.PostalCode).HasColumnType("nvarchar").HasMaxLength(20).IsOptional();

            Property(p => p.Country).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.HomePhone).HasColumnType("nvarchar").HasMaxLength(48).IsOptional();

            Property(p => p.Extension).HasColumnType("nvarchar").HasMaxLength(8).IsOptional();

            Property(p => p.Photo).HasColumnType("image").IsOptional();

            Property(p => p.Notes).HasColumnType("ntext").IsOptional();

            Property(p => p.ReportsTo).HasColumnType("int").IsOptional();

            Property(p => p.PhotoPath).HasColumnType("nvarchar").HasMaxLength(510).IsOptional();

            //HasOptional(p => p.FkEmployeesEmployees).WithMany(p => p.Employees).HasForeignKey(p => p.ReportsTo).WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
