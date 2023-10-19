using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProductBl(Product product)
        {
            _productDal.Add(product);
        }

        public void DeleteProductBl(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAktifList()
        {
            return _productDal.List(x => x.ProductStatus == true);
        }

        public List<Product> GetAllList()
        {
            return _productDal.List();
        }

        public Product GetByID(int id)
        {
            return _productDal.Get(x=>x.ProductID == id);
        }

        public void UpdateProductBl(Product product)
        {
            _productDal.Update(product);
        }
    }
}
