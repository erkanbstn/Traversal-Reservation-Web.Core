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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _AnnouncementDal;

        public AnnouncementManager(IAnnouncementDal AnnouncementDal)
        {
            _AnnouncementDal = AnnouncementDal;
        }

        public void YouCanDelete(Announcement t)
        {
            _AnnouncementDal.Delete(t);
        }

        public Announcement YouCanGetById(int id)
        {
            return _AnnouncementDal.GetById(id);
        }

        public void YouCanInsert(Announcement t)
        {
            _AnnouncementDal.Insert(t);
        }

        public List<Announcement> YouCanList()
        {
            return _AnnouncementDal.GetAll();
        }

        public List<Announcement> YouCanListById(Expression<Func<Announcement, bool>> filter)
        {
            return _AnnouncementDal.GetByIdList(filter);
        }

        public void YouCanUpdate(Announcement t)
        {
            _AnnouncementDal.Update(t);
        }
    }
}
