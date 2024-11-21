using ApiColegio.Domain.Models;
using ApiColegio.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Bd Config
builder.Services.AddDbContext<AppDbContext>(opciones =>
{
    opciones.UseMySql(builder.Configuration.GetConnectionString("Database"), new MySqlServerVersion("8.0"));
});

// Add services 
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
