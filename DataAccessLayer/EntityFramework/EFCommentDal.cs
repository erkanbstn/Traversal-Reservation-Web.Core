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
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentByDetail()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(b => b.Destination).Include(b => b.AppUser).ToList();
            };
        }
        public List<Comment> GetCommentByUser(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Where(b=>b.AppUserId==id).Include(b=>b.Destination).Include(b => b.AppUser).ToList();
            };
        }
    }
}
