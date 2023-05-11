using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _ContactDal;

        public ContactManager(IContactDal ContactDal)
        {
            _ContactDal = ContactDal;
        }

        public void YouCanDelete(Contact t)
        {
            _ContactDal.Delete(t);
        }

        public Contact YouCanGetById(int id)
        {
            return _ContactDal.GetById(id);
        }

        public void YouCanInsert(Contact t)
        {
            _ContactDal.Insert(t);
        }

        public List<Contact> YouCanList()
        {
            return _ContactDal.GetAll();
        }

        public List<Contact> YouCanListById(Expression<Func<Contact, bool>> filter)
        {
            return _ContactDal.GetByIdList(filter);
        }

        public void YouCanUpdate(Contact t)
        {
            _ContactDal.Update(t);
        }
    }
}
