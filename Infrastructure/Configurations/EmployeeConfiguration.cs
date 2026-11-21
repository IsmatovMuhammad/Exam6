using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName);
        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.HireDate);
        builder.Property(x => x.Salary);
        builder.Property(x => x.IsActive);

        builder.HasIndex(x => x.Email).IsUnique();

        builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId)
        .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Position).WithMany().HasForeignKey(x => x.PositionId)
        .OnDelete(DeleteBehavior.Restrict);

    }

}
