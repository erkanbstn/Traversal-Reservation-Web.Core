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
    public class About2Manager : IAbout2Service
    {
        IAbout2Dal _About2Dal;

        public About2Manager(IAbout2Dal About2Dal)
        {
            _About2Dal = About2Dal;
        }
        public void YouCanDelete(About2 t)
        {
            _About2Dal.Delete(t);
        }

        public About2 YouCanGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void YouCanInsert(About2 t)
        {
            _About2Dal.Insert(t);
        }

        public List<About2> YouCanList()
        {
            return _About2Dal.GetAll();
        }

        public List<About2> YouCanListById(Expression<Func<About2, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void YouCanUpdate(About2 t)
        {
            _About2Dal.Update(t);
        }
    }
}
