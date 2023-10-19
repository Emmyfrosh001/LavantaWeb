using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal; 

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategoryBl(Category category)
        {
            _categoryDal.Add(category);
        }

        public void DeleteCategoryBl(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAktifAllList()
        {
            return _categoryDal.List(x => x.CategoryStatus == true);
        }

        public List<Category> GetAllList()
        {
            return _categoryDal.List();
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id);
        }

        public void UpdateCategoryBl(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
