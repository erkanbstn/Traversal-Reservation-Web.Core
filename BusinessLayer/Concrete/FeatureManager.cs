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
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void YouCanDelete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public Feature YouCanGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void YouCanInsert(Feature t)
        {
            _featureDal.Insert(t);
        }

        public List<Feature> YouCanList()
        {
            return _featureDal.GetAll();
        }

        public List<Feature> YouCanListById(Expression<Func<Feature, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void YouCanUpdate(Feature t)
        {
            _featureDal.Update(t);
        }
    }
}
