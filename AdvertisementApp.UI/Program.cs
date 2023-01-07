using AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AdvertisementApp.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvertisementContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:Local").Value));

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
