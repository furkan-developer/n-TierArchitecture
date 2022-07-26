using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.CrossCuttingConcerns.Caching.Abstract;
using WebAPI.Core.CrossCuttingConcerns.Caching.Concrete.Microsoft;
using WebAPI.Core.IoC;

namespace WebAPI.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {         
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddMemoryCache();

            services.AddSingleton<Stopwatch>();
        }
    }
}
