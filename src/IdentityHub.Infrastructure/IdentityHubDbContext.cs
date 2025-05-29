using Microsoft.EntityFrameworkCore;
using IdentityHub.Domain.Entities;

namespace IdentityHub.Infrastructure;

public class IdentityHubDbContext : DbContext
{
     public IdentityHubDbContext(DbContextOptions<IdentityHubDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User => Set<User>();
    public virtual DbSet<Role> Role => Set<Role>();
    public virtual DbSet<UserRole> UserRole => Set<UserRole>()  ;
    public virtual DbSet<LoginHistory> LoginHistory => Set<LoginHistory>();
}
