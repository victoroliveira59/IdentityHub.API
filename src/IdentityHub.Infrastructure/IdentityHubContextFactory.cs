using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IdentityHub.Infrastructure;

public class IdentityHubDbContextFactory : IDesignTimeDbContextFactory<IdentityHubDbContext>
{
    public IdentityHubDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "IdentityHub.API"))
            .AddJsonFile("appsettings.json", optional: true)
            .Build();


        var builder = new DbContextOptionsBuilder<IdentityHubDbContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString);

        return new IdentityHubDbContext(builder.Options);
    }
}
