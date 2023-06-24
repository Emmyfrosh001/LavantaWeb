using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Contact
    {
        public int ContactID { get; set; }      //İletişim Bilgi ID
        public string UserName { get; set; }    //Kullanıcı Adı
        public string UserMail { get; set; }    //Kullanıcı Mail Adresi
        public string Subject { get; set; }     //Mesajın Konusu
        public string Message { get; set; }     //Mesaj
    }
}
