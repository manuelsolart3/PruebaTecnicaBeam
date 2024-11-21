using ApiColegio.Domain;
using ApiColegio.Domain.Abstractions;
using ApiColegio.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Infrastructure.Context;


public class AppDbContext : IdentityDbContext<User>, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public override DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        builder.Ignore<IdentityRole>(); 
        builder.Ignore<IdentityUserRole<string>>(); 
        builder.Ignore<IdentityRoleClaim<string>>();
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
