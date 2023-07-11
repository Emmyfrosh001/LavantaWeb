using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int ProductPiece { get; set; }  //Ürün Adet
        public float ProductUnitPrice { get; set; }  //Ürün Birim Fiyatı

        public int OrderID { get; set; } //Sipariş ID
        public virtual Order Order { get; set; }//Sipariş tablosu ile ilişkilendirme

        public int ProductID { get; set; }  //Ürün ID
        public virtual Product Product { get; set; }    //Ürün Tablosu ile ilişkilendirme

    }
}
