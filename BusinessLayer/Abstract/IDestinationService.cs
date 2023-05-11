using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        List<Destination> YouCanGetBy3();
        void TSetTrueStatus(int id);
        void TSetFalseStatus(int id);
    }
}
