﻿using AutoMapper;
using EquinoxCore.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquinoxCore.Web.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services) {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Startup));

            AutoMapperConfig.RegisterMappings();
        }
    }
}
