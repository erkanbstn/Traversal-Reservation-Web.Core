using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetAll();
        List<T> GetByIdList(Expression<Func<T, bool>> filter);
        T GetById(int id);
    }
}
