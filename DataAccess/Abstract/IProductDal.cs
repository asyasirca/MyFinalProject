using Core.DataAccess;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }//bu ürünleri category'e göre filtrele
}

//Code refactoring: kodun iyileştirilmesi
