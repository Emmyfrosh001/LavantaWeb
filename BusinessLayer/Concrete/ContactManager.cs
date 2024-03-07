using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddContactBl(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void DeleteContactBl(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public List<Contact> GetAllList()
        {
            return _contactDal.List();
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public void UpdateContactBl(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
