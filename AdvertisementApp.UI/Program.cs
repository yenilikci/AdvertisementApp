using AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AdvertisementApp.DataAccess;
using AdvertisementApp.UI.Models;
using AdvertisementApp.UI.ValidationRules;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvertisementContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:Local").Value));

builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
