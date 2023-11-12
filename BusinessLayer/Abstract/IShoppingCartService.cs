using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IShoppingCartService
    {
        List<ShoppingCart> GetAllList();
        List<ShoppingCart> GetUserList(int id);
        void AddShoppingCartBl(ShoppingCart shoppingCart);
        ShoppingCart GetByID(int UserId, int ProductId);
        ShoppingCart GetByID(int id);
        void UpdateShoppingCartBl(ShoppingCart shoppingCart);
        void DeleteShoppingCartBl(ShoppingCart shoppingCart);
    }
}
