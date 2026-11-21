using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.ToTable("LeaveRequests");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LeaveType);
        builder.Property(x => x.StartDate);
        builder.Property(x => x.EndDate);
        builder.Property(x => x.Status);
        builder.Property(x => x.Reason);
        builder.Property(x => x.Reason);
        builder.Property(x => x.CreatedAt);
        
        builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
