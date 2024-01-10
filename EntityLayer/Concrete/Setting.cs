using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Setting
    {
        [Key]
        public int SettingID { get; set; }        //Hakkımızda ID
        [StringLength(250)]
        public string Announcement { get; set; }     //Duyuru

        public int CargoPrice { get; set; }     //Kargo Ücreti
    }
}
