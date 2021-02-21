﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic cobstraint: jenerik kısıt
    //class: referans tip
    //IEntity:IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new: 
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//bizim aramalarda filtreler yazmamızı sağlıyor
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
