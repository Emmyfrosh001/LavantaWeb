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
            return _orderDal.Get(x=>x.OrderID==id);
        }

        public List<Order> GetUserList(int UserId)
        {
            return _orderDal.List(x=>x.UserID==UserId);
        }

        public void UpdateOrderBl(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
