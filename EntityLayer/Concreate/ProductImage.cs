using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public  class ProductImage
    {
        public int ProductImageID { get; set; }
        public string ProductImageAdress { get; set; }
        public string ProductImageStatus { get; set;}

        public int ProductID { get; set; }
        public virtual Product Products { get; set; }
    }
}
