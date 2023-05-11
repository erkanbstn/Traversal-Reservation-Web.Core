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
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void TSetFalseStatus(int id)
        {
            _destinationDal.SetFalseStatus(id);
        }

        public void TSetTrueStatus(int id)
        {
            _destinationDal.SetTrueStatus(id);
        }

        public void YouCanDelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public List<Destination> YouCanGetBy3()
        {
           return _destinationDal.GetDestinationsBy3();
        }

        public Destination YouCanGetById(int id)
        {
           return _destinationDal.GetById(id);
        }

        public void YouCanInsert(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public List<Destination> YouCanList()
        {
            return _destinationDal.GetAll();
        }

        public List<Destination> YouCanListById(Expression<Func<Destination, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void YouCanUpdate(Destination t)
        {
            _destinationDal.Update(t);
        }
    }
}
