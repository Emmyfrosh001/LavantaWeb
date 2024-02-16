using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }        //İlçe ID
        [StringLength(250)]
        public string DistrictName { get; set; }     //İlçe adı

        public int CityID { get; set; }  //il ID
        public virtual City city { get; set; }    //il Tablosu ile ilişkilendirme
    }
}
