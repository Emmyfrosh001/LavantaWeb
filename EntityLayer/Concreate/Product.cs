using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Product
    {
        public int ProductID { get; set; }  //Ürün ID
        public string ProductName { get; set; } //Ürün Adı
        public string ProductDescription { get; set; }  //Ürün Açıklaması
        public int ProductStock { get; set; }  //Ürün Stok Sayısı
        public float ProductPrice { get; set; }  //Ürün Fiyatı
        public string ProductNote { get; set; }  //Ürün Notu
        public float ProductDiscount { get; set; } //Ürün indirim Miktarı
        public bool ProductDiscountStatus { get; set; }  //Ürün İndirim Durumu
        public bool ProductStatus { get; set; }  //Ürün Durumu
        public int ProductDetailObserveCount { get; set; }  //Ürün Detay görüntülenme sayısı
        public int ProductBasketInsertCount { get; set; }  //Ürün Sepete Ekleme Sayısı
        public int ProductBasketDeleteCount { get; set; }  //Ürün Sepetten Silinme Sayısı
        public int ProductSellCount { get; set; }  //Ürün Satın alınma sayısı
        public int ProductReturnCount { get; set; }  //Ürün Iade sayısı


        public int CategoryID { get; set; }     //Ürün Kategori ID
        public virtual Category Category { get; set; }  //Kategori tablosu ile ilişkilendirme

        public ICollection<ProductImage> ProductImages { get; set; }    //Ürün Resim Tablosu ile ilişkilendirme


    }
}
