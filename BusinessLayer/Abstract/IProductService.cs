using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllList();
        List<Product> GetAktifList();
        void AddProductBl(Product product);
        Product GetByID(int id);
        void UpdateProductBl(Product product);
        void DeleteProductBl(Product product);
    }
}
