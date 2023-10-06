using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllList();
        void AddCategoryBl(Category category);
        Category GetByID(int id);
        void UpdateCategoryBl(Category category);
        void DeleteCategoryBl(Category category);
    }
}
