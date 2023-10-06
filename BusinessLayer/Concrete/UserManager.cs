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
            _userDal.Add(user);
        }

        public void DeleteUserBl(User user)
        {
            _userDal.Delete(user);
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
            _userDal.Update(user);
        }
    }
}
