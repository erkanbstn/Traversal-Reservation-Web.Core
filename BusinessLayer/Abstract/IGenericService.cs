using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void YouCanInsert(T t);
        void YouCanDelete(T t);
        void YouCanUpdate(T t);
        List<T> YouCanList();
        T YouCanGetById(int id);
        List<T> YouCanListById(Expression<Func<T, bool>> filter);
    }
}
