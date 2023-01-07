﻿using AdvertisementApp.Business.Mappings.AutoMapper;
using AdvertisementApp.Business.ValidationRules;
using AdvertisementApp.DataAccess;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.ProvidedServicesDtos;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("ConnectionStrings:Local"));
            });

            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProvidedServiceProfile());
            });


            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
        }
    }
}
