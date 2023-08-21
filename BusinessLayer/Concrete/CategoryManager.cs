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
    public class CategoryManager
    {
        GenericRepository<Category> repository =new GenericRepository<Category>();

        public List<Category> GetAllBl()
        {
            return repository.List();
        }
        public void CategoryAddBl(Category parametre)
        {
            if(parametre.CategoryName==""||parametre.CategoryName.Length<3||parametre.CategoryName.Length>=51)
            {
                //hata mesajı
            }
            else
            {
                repository.Add(parametre);
            }
        }
    }
}
