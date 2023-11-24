using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAllList();
        List<OrderDetail> GetOrderDetailList(int OrderId);
        OrderDetail GetByID(int id);
        void AddorderDetailBl(OrderDetail orderDetail);
        void UpdateorderDetailBl(OrderDetail orderDetail);
    }
}
