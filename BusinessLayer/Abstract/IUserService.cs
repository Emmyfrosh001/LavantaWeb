using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetAllList();
        User GetByID(int id);
        User GetBySession(string session);
        void AddUserBl(User user);
        void UpdateUserBl(User user);
        void DeleteUserBl(User user);

    }
}
