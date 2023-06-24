using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryUst { get; set; }
        public bool CategoryStatus { get; set; }

        public ICollection<Product> Products { get; set; }  //Ürün tablosu ile ilişkilendirme
    }
}
