﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.IoC;

namespace WebAPI.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection services,ICoreModule[] modules)
        {
            foreach (var item in modules)
            {
                item.Load(services);
            }
            return ServiceTool.Create(services);
        }
    }
}
