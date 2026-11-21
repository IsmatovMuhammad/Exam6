using System.Security.Cryptography.X509Certificates;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");

        builder.HasKey(x => x.id);
        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.CreatedAt);
    }

}
