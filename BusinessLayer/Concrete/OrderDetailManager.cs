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
    public class OrderDetailManager:IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal) 
        {
            _orderDetailDal = orderDetailDal;
        }

        public void AddorderDetailBl(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
        }

        public List<OrderDetail> GetAllList()
        {
            return _orderDetailDal.List();
        }

        public OrderDetail GetByID(int id)
        {
            return _orderDetailDal.Get(x=>x.OrderDetailID==id);
        }

        public List<OrderDetail> GetOrderDetailList(int OrderId)
        {
            return _orderDetailDal.List(x => x.OrderID == OrderId);
        }

        public void UpdateorderDetailBl(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
        }
    }
}
