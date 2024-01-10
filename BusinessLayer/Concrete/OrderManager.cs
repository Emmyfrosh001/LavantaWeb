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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void AddOrderBl(Order order)
        {
            _orderDal.Add(order);
        }

        public List<Order> GetAllList()
        {
            return _orderDal.List();
        }

        public Order GetByID(int id)
        {
            return _orderDal.Get(x => x.OrderID == id);
        }

        public int FindOrderId(int UserId, DateTime datetime)
        {
            return _orderDal.Get(x => x.UserID == UserId && x.OrderDateTime == datetime).OrderID;
        }

        public List<Order> GetOrderUserList(int UserId)
        {
            return _orderDal.List(x => x.UserID == UserId);
        }

        public void UpdateOrderBl(Order order)
        {
            _orderDal.Update(order);
        }

        public Order GetOrderId(int UserId, DateTime datetime)
        {
            return _orderDal.Get(x => x.UserID == UserId && x.OrderDateTime == datetime);
        }
    }
}
