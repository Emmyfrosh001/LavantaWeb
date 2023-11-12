using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ShoppingCartManager : IShoppingCartService
    {
        IShoppingCartDal _shoppingCartDal;
        public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
        {
            _shoppingCartDal = shoppingCartDal;
        }
        public void AddShoppingCartBl(ShoppingCart shoppingCart)
        {
            _shoppingCartDal.Add(shoppingCart);
        }

        public void DeleteShoppingCartBl(ShoppingCart shoppingCart)
        {
            _shoppingCartDal.Delete(shoppingCart);
        }

        public List<ShoppingCart> GetAllList()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetByID(int id)
        {
            return _shoppingCartDal.Get(x => x.CartID == id);
        }

        public ShoppingCart GetByID(int UserId, int ProductId)
        {
            return _shoppingCartDal.Get(x => x.UserID == UserId && x.ProductID== ProductId);
        }

        public List<ShoppingCart> GetUserList(int id)
        {
            return _shoppingCartDal.List(x => x.UserID == id);
        }

        public void UpdateShoppingCartBl(ShoppingCart shoppingCart)
        {
            _shoppingCartDal.Update(shoppingCart);
        }
    }
}
