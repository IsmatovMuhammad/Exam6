using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("Positions");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title);
        builder.Property(x => x.MinSalary);
        builder.Property(x => x.MaxSalary);
    }

}
