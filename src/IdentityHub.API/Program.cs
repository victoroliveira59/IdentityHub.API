using Microsoft.EntityFrameworkCore;
using IdentityHub.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IdentityHubDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
