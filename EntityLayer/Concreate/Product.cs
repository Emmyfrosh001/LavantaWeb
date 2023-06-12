using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductStock { get; set; }
        public float ProductPrice { get; set; }
        public string ProductNote { get; set; }
        public float ProductDiscount { get; set; }
        public bool ProductDiscountStatus { get; set; }
        public bool ProductStatus { get; set; }
        public int ProductDetailObserveCount { get; set; }
        public int ProductBasketInsertCount { get; set; }
        public int ProductBasketDeleteCount { get; set; }
        public int ProductSellCount { get; set;}
        public int ProductReturnCount { get; set;}
    }
}
