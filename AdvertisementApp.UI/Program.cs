using AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AdvertisementApp.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvertisementContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:Local").Value));

builder.Services.AddControllersWithViews();
builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
