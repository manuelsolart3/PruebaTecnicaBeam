using ApiColegio.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired(true);
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired(true);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired(true);
        builder.Property(u => u.DateOfBirth).IsRequired(true);
        builder.Property(u => u.Role).HasMaxLength(50).IsRequired(true);
        builder.Property(u => u.StartDate).IsRequired(true);
        builder.Property(u => u.Status).HasDefaultValue(true); 
    }
}