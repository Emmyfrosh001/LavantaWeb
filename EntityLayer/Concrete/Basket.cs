using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public  class Basket
    {
        public int BasketID { get; set; }

        public int UserID { get; set; }//Kullanıcı ID
        public virtual User User { get; set; }   //Kullanıcı Tablosu ile ilişkilendirme

        public int ProductID { get; set; }  //Ürün ID
        public virtual Product Product { get; set; }    //Ürün Tablosu ile ilişkilendirme

        public int ProductPiece { get; set; }  //Ürün Adet
    }
}