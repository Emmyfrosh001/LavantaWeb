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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUserBl(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserBl(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllList()
        {
            return _userDal.List();
        }

        public User GetByID(int id)
        {
            return _userDal.Get(x=>x.UserID==id);
        }

        public void UpdateUserBl(User user)
        {
            throw new NotImplementedException();
        }
    }
}
