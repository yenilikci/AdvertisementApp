using AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AdvertisementApp.Business.Helpers;
using AdvertisementApp.DataAccess;
using AdvertisementApp.UI.Mappings.AutoMapper;
using AdvertisementApp.UI.Models;
using AdvertisementApp.UI.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvertisementContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:Local").Value));

builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "AdvertisementCookie";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
});

var Profiles = ProfileHelper.GetProfiles();
Profiles.Add(new UserCreateModelProfile());
var configuration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(Profiles);
});

var mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
