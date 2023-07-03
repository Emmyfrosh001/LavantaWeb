using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }        //Hakkımızda ID
        public string AboutDetails { get; set;}     //Hakkımızda Detay 1
        public string AboutDetails2 { get; set; }     //Hakkımızda Detay 2
        public string AboutImage { get; set; }     //Hakkımızda Resim 1
        public string AboutImage2 { get; set; }           //Hakkımızda Resim 2
    }
}
