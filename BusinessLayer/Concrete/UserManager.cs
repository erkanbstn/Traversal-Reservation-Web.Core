using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _UserDal;

        public UserManager(IUserDal UserDal)
        {
            _UserDal = UserDal;
        }
        public void YouCanDelete(AppUser t)
        {
            _UserDal.Delete(t);
        }

        public AppUser YouCanGetById(int id)
        {
            return _UserDal.GetById(id);

        }

        public void YouCanInsert(AppUser t)
        {
            _UserDal.Insert(t);
        }

        public List<AppUser> YouCanList()
        {
            return _UserDal.GetAll();
        }

        public List<AppUser> YouCanListById(Expression<Func<AppUser, bool>> filter)
        {
            return _UserDal.GetByIdList(filter);

        }

        public void YouCanUpdate(AppUser t)
        {
            _UserDal.Update(t);
        }
    }
}
