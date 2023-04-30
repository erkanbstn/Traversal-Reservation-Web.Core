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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void YouCanDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About YouCanGetById(int id)
        {
           throw new NotImplementedException();
        }

        public void YouCanInsert(About t)
        {
            _aboutDal.Insert(t);
        }

        public List<About> YouCanList()
        {
            return _aboutDal.GetAll();
        }

        public List<About> YouCanListById(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void YouCanUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
