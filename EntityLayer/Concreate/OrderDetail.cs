using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; } //Sipariş ID
        public virtual Order Order { get; set; }//Sipariş tablosu ile ilişkilendirme

        public int ProductID { get; set; }  //Kullanıcı ID
        public virtual Product Product { get; set; }    //Kullanıcı Tablosu ile ilişkilendirme

        public int ProductPiece { get; set; }  //Ürün Adet
        public float ProductUnitPrice { get; set; }  //Ürün Birim Fiyatı
    }
}
