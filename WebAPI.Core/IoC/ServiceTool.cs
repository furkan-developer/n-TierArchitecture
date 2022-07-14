using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}

#region Explanation
    /* 
     * Ascept' ler proje akışı dışında bir operasyon olduğundan IoC hizmet veremez.
     * IoC hizmetini kullanmak için bir tool yazıldı.
     * Bu tool uygulamanın kullandığı IoC Container ı bize verir ve bunun üzerinden
     * istenilen referans çekilir.
     */
#endregion
