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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _NewsLetterDal;

        public NewsLetterManager(INewsLetterDal NewsLetterDal)
        {
            _NewsLetterDal = NewsLetterDal;
        }

        public void YouCanDelete(NewsLetter t)
        {
            _NewsLetterDal.Delete(t);
        }

        public NewsLetter YouCanGetById(int id)
        {
            return _NewsLetterDal.GetById(id);
        }

        public void YouCanInsert(NewsLetter t)
        {
            _NewsLetterDal.Insert(t);
        }

        public List<NewsLetter> YouCanList()
        {
            return _NewsLetterDal.GetAll();
        }

        public List<NewsLetter> YouCanListById(Expression<Func<NewsLetter, bool>> filter)
        {
            return _NewsLetterDal.GetByIdList(filter);
        }

        public void YouCanUpdate(NewsLetter t)
        {
            _NewsLetterDal.Update(t);
        }
    }
}
