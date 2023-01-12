using AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AdvertisementApp.Business.Helpers;
using AdvertisementApp.DataAccess;
using AdvertisementApp.UI.Mappings.AutoMapper;
using AdvertisementApp.UI.Models;
using AdvertisementApp.UI.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvertisementContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:Local").Value));

builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
builder.Services.AddControllersWithViews();

var Profiles = ProfileHelper.GetProfiles();
Profiles.Add(new UserCreateModelProfile());
var configuration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(Profiles);
});

var mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
