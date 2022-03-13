using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        //cachede kalma süresi 60dk
      public CacheAspect(int duration = 60)
        {
            _duration = duration;
            
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //breakpoint koy degerleri test et
            //metotlara unique id atamak icin namespace.metotadi... gibi full path adi alıyoruz
            //amac aop yapmak icin her metota unique bir id belirlemek
           //namespace + class ismi
           //                Northwind.Business.IProductService.                         GetAll
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            
            //ilgili metodun argumanlarini listeye cevir.
            var arguments = invocation.Arguments.ToList();
            //                                                       NULL =boyle bir cache varmı bellekte
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                //cache de varsa metotu hiç çalıştırma  
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }

}