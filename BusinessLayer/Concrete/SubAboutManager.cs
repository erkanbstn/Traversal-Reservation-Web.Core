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
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _SubAboutDal;

        public SubAboutManager(ISubAboutDal SubAboutDal)
        {
            _SubAboutDal = SubAboutDal;
        }

        public void YouCanDelete(SubAbout t)
        {
            _SubAboutDal.Delete(t);
        }

        public SubAbout YouCanGetById(int id)
        {
            return _SubAboutDal.GetById(id);
        }

        public void YouCanInsert(SubAbout t)
        {
            _SubAboutDal.Insert(t);
        }

        public List<SubAbout> YouCanList()
        {
            return _SubAboutDal.GetAll();
        }

        public List<SubAbout> YouCanListById(Expression<Func<SubAbout, bool>> filter)
        {
            return _SubAboutDal.GetByIdList(filter);
        }

        public void YouCanUpdate(SubAbout t)
        {
            _SubAboutDal.Update(t);
        }
    }
}
