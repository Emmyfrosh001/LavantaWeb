using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        IAdminDal _adminDal;
        public RoleManager(IAdminDal adminDal) 
        {
            _adminDal = adminDal;
        }
        public Admin GetByUserName(string username)
        {
            return _adminDal.Get(x => x.AdminName == username);
        }
    }
}
