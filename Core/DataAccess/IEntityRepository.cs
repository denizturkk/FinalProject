using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //sınırlandırma generic constraint 
    // T:class --->>>> T referans tip olmalı demek class demek degil
    //T:IEntity ---->>>>>IEntity olabilir veya ondan inherit edilmiş bir nesne olabilir.
    //new() ---->>>> new lenebilir olmalı (IEntity'nin sout olan kısmını yani sadece interface'ini
    //devre dışı bırakmış olduk )
    public interface IEntityRepository<T> where T :class ,IEntity,new()
    {
        //delegates
       List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter= null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
  

    }
}
