using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAllList();
        List<Order> GetUserList(int UserId);
        Order GetByID(int id);
        void AddOrderBl(Order order);
        void UpdateOrderBl(Order order);
    }
}
