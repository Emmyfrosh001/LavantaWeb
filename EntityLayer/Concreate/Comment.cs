using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public  class Comment   //Yorum
    {
        public int CommentID { get; set; }//Yorum ID
        public string CommentDetail { get; set; }   //Yorum Detayı
        public DateTime CommentDateTime { get; set; }   //Yorum Zamanı
        public bool CommentStatus { get; set; }    //Yorum Durumu

        public int UserID { get; set; }//Kullanıcı ID
        public virtual User User { get; set; }   //Kullanıcı Tablosu ile ilişkilendirme

        public int ProductID { get; set; }  //Ürün ID
        public virtual Product Product { get; set; }    //Ürün Tablosu ile ilişkilendirme

    }
}
