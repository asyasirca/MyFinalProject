using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;//bağımlılığımızı minimize etmem lazım.
        //bağımlılığımı constructor injection ile yapıyorum.

        public CategoryManager(ICategoryDal categoryDal)//ben categorymanager olarak veri erişim katmanna bağımlıyım ama zayıf bağımlıyım. 
            //ben interface üzerinden referans üzerinden bağımlıyım.
            //o yüzden sen dataaccess katmanında istediğini yap yeterki kurallarıma uy
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Category>> ( _categoryDal.GetAll());
        }

        //select * from Categories where CategoryId = 3

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>( _categoryDal.Get(c => c.CategoryId == categoryId));
            //c için c nin CategoryId si benim gönderdğim categoryid sine eşitse
           
        }
        
    }
}
