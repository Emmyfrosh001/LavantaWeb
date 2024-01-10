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
        List<Order> GetOrderUserList(int UserId);
        int FindOrderId(int UserId, DateTime datetime);
        Order GetOrderId(int UserId, DateTime datetime);
        Order GetByID(int id);
        void AddOrderBl(Order order);
        void UpdateOrderBl(Order order);
    }
}
