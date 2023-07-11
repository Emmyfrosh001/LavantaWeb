using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Order  //Sipariş
    {
        [Key]
        public int OrderID { get; set; } //Sipariş ID
        public DateTime OrderDateTime { get; set; } //Sipariş Tarihi

        [StringLength(50)]
        public string OrderState { get; set; } //Sipariş Güncel Durumu

        [StringLength(50)]
        public string OrderPayType { get; set; } //Sipariş Ödeme Türü
        public float OrderPrice { get; set; }    //Sipariş Tutarı

        [StringLength(250)]
        public string OrderAddress { get; set; } //Sipariş Adresi

        [StringLength(50)]
        public string OrderCargoPrice { get; set; } //Sipariş Kargo Ücreti

        public int UserID { get; set; }  //Kullanıcı ID
        public virtual User User { get; set; }    //Kullanıcı Tablosu ile ilişkilendirme


        public ICollection<OrderDetail> OrderDetails { get; set; }    //Sipariş Detay Tablosu ile ilişkilendirme
    }
}
