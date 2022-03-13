using Core.CrossCuttingConserns.Caching;
using Core.CrossCuttingConserns.Caching.Microsoft;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //uygulama seviyesinde servis bagimliliklarimizi koyacagimiz yer
        //businesssta bagımlılıkşarı api yerine autofac ile daha geriye tasimistik
        public void Load(IServiceCollection serviceCollection)
        {
            //memoryCache servisini implemente ettik
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            //MemoryCache icin interface'in karsiligini olusturduk 
            //ileride alternatif servislerle calismak istersem güncelleyeceğim
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
