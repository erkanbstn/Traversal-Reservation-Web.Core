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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _TestimonialDal;

        public TestimonialManager(ITestimonialDal TestimonialDal)
        {
            _TestimonialDal = TestimonialDal;
        }

        public void YouCanDelete(Testimonial t)
        {
            _TestimonialDal.Delete(t);
        }

        public Testimonial YouCanGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void YouCanInsert(Testimonial t)
        {
            _TestimonialDal.Insert(t);
        }

        public List<Testimonial> YouCanList()
        {
            return _TestimonialDal.GetAll();
        }

        public List<Testimonial> YouCanListById(Expression<Func<Testimonial, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void YouCanUpdate(Testimonial t)
        {
            _TestimonialDal.Update(t);
        }
    }
}
