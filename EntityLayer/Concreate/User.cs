using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserImage { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserCity { get; set; }
        public string UserDistrict { get; set; }
        public string UserAddress { get; set; }
        public bool UserStatus { get; set; }
    }
}
