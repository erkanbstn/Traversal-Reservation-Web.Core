using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListByUsers(int id)
        {
            using (var c = new Context())
            {
                return c.Reservations.Where(b=>b.AppUserId==id).Include(b => b.AppUser).Include(b=>b.Destination).ToList();
            }
        }
    }
}
