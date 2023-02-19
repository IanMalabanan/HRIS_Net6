using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.Domain.Entities;

namespace HRIS.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(t => t.EmpID);

            builder.Property(t => t.EmpID)
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.Property(t => t.EmpID)
                .HasMaxLength(15)
                //.HasComputedColumnSql("'Emp-'" + " + FORMAT([SerialID], '000000000')")
                //.IsRequired()
                ;

            builder.Property(t => t.LastName)
                .IsRequired();

            builder.Property(t => t.FirstName)
                .IsRequired();

            builder.Property(t => t.MiddleName);

            builder.Property(t => t.DepartmentCode)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(t => t.DepartmentSectionCode)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(t => t.DateCreated).IsRequired();

            builder.Property(t => t.CreatedBy)
                .IsRequired();

            builder.Property(t => t.ModifiedBy);

            builder.Property(t => t.DateModified);

            builder.Property(t => t.DeletedBy);


            builder.Property(t => t.DeletedDate);

            builder.Property(t => t.ModifiedBy);


            builder.Property(t => t.IsDeleted);



            builder.HasOne(t => t.Department)
                .WithMany()
                .HasForeignKey(t => t.DepartmentCode)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(t => t.DepartmentSection)
                .WithMany()
                .HasForeignKey(t => new { t.DepartmentCode, t.DepartmentSectionCode })
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
