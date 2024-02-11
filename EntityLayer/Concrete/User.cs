using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }     //Kullanıcı ID
        [StringLength(50)]
        public string UserName { get; set; }     //Kullanıcı Adı
        [StringLength(50)]
        public string UserSurname { get; set; }     //Kullanıcı Soyadı
        [StringLength(250)]
        public string UserImage { get; set; }     //Kullanıcı Resmi
        [StringLength(50)]
        public string UserMail { get; set; }     //Kullanıcı Mail Adresi
        [StringLength(200)]
        public string UserPassword { get; set; }     //Kullanıcı Parolası
        [StringLength(10)]
        public string UserPhoneNumber { get; set; }     //Kullanıcı Telefon Numarası
        [StringLength(15)]
        public string UserCity { get; set; }     //Kullanıcının Yaşadığı Şehir
        [StringLength(16)]
        public string UserDistrict { get; set; }     //Kullanıcının Yaşadığı ilçe
        [StringLength(33)]
        public string LoginInfo { get; set; }     //Login Bilgisi Şifreli
        [StringLength(250)]
        public string UserAddress { get; set; }     //Kullanıcının açık adresi
        public bool UserStatus { get; set; }     //Kullanıcı Durumu (Websitesine erişimi olacak mı engellenecek mi)

        public ICollection<Order> Orders { get; set; }    //Sipariş Tablosu ile ilişkilendirme
        public ICollection<Comment> Comments { get; set; }     //Yorum Tablosu ile ilişkilendirme
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }     //Yorum Tablosu ile ilişkilendirme
    }
}
