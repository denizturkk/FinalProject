using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Ioc
{
    //this is for enability to create injections that we created in webApi 
    // or Autofac 
    //web api ve autofac'te oluştuduğumuz injectionları oluşturmaya yarıyor.
    //using this code we can get the corresponding interface services
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        //.net servisleri al
        public static IServiceCollection Create(IServiceCollection services)
        {
            //o servisleri build et
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
