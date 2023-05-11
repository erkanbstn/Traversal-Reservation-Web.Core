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
    public class GuideManager : IGuideService
    {
        IGuideDal _GuideDal;
        public GuideManager(IGuideDal GuideDal)
        {
            _GuideDal = GuideDal;
        }

        public void YouCanDelete(Guide t)
        {
            _GuideDal.Delete(t);
        }

        public Guide YouCanGetById(int id)
        {
           return _GuideDal.GetById(id);
        }

        public void YouCanInsert(Guide t)
        {
            _GuideDal.Insert(t);
        }

        public List<Guide> YouCanList()
        {
            return _GuideDal.GetAll();
        }

        public List<Guide> YouCanListById(Expression<Func<Guide, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void YouCanUpdate(Guide t)
        {
            _GuideDal.Update(t);
        }
    }
}
