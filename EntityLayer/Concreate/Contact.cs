using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }      //İletişim Bilgi ID
        [StringLength(50)]
        public string UserName { get; set; }    //Kullanıcı Adı
        [StringLength(50)]
        public string UserMail { get; set; }    //Kullanıcı Mail Adresi
        [StringLength(50)]
        public string Subject { get; set; }     //Mesajın Konusu
        [StringLength(250)]
        public string Message { get; set; }     //Mesaj
    }
}
