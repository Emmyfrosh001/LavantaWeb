using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal:IRepository<Category>
    {
        //CRUD Operasyonları
        //Type Name();
        //List<Category> List();

        //void Add(Category p);
        //void Update(Category p);
        //void Delete(Category p);
    }
}
