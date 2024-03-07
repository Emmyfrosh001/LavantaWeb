using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAllList();
        Contact GetByID(int id);
        void AddContactBl(Contact contact);
        void UpdateContactBl(Contact contact);
        void DeleteContactBl(Contact contact);
    }
}
