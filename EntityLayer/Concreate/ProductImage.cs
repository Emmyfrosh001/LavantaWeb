using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public  class ProductImage
    {
        public int ProductImageID { get; set; }    //Ürün Resim ID
        public string ProductImageAdress { get; set; }    //Ürün Resim Yolu
        public string ProductImageStatus { get; set; }    //Ürün Resim Durumu

        public int ProductID { get; set; }  //Ürün ID
        public virtual Product Products { get; set; }    //Ürün Tablosu ile ilişkilendirme
    }
}
