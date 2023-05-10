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
    public class ReservationManager : IReservationService
    {
        IReservationDal _ReservationDal;

        public ReservationManager(IReservationDal ReservationDal)
        {
            _ReservationDal = ReservationDal;
        }

        public List<Reservation> TGetListByUsers(int id)
        {
            return _ReservationDal.GetListByUsers(id);
        }

        public void YouCanDelete(Reservation t)
        {
            _ReservationDal.Delete(t);
        }

        public Reservation YouCanGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void YouCanInsert(Reservation t)
        {
            _ReservationDal.Insert(t);
        }

        public List<Reservation> YouCanList()
        {
            return _ReservationDal.GetAll();
        }

        public List<Reservation> YouCanListById(Expression<Func<Reservation, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void YouCanUpdate(Reservation t)
        {
            _ReservationDal.Update(t);
        }
    }
}
