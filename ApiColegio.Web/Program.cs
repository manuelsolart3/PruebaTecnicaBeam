using ApiColegio.Domain.Models;
using ApiColegio.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using ApiColegio.Infrastructure.Extensions;
using ApiColegio.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services 
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.AllowedUserNameCharacters = null;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();



// Configuración básica de API y controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();  // Mapea todos los controladores

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
