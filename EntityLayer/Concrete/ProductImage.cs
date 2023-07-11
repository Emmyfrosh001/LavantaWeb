using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public  class ProductImage
    {
        [Key]
        public int ProductImageID { get; set; }    //Ürün Resim ID
        [StringLength(150)]
        public string ProductImageAdress { get; set; }    //Ürün Resim Yolu
        public bool ProductImageStatus { get; set; }    //Ürün Resim Durumu

        public int ProductID { get; set; }  //Ürün ID
        public virtual Product Product { get; set; }    //Ürün Tablosu ile ilişkilendirme
    }
}
