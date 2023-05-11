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
    public class CommentManager : ICommentService
    {
        ICommentDal _CommentDal;

        public CommentManager(ICommentDal CommentDal)
        {
            _CommentDal = CommentDal;
        }

        public List<Comment> TGetCommentByDetail()
        {
            return _CommentDal.GetCommentByDetail();
        }

        public List<Comment> TGetCommentByUser(int id)
        {
            return _CommentDal.GetCommentByUser(id);
        }

        public void YouCanDelete(Comment t)
        {
            _CommentDal.Delete(t);
        }

        public Comment YouCanGetById(int id)
        {
            return _CommentDal.GetById(id);
        }

        public void YouCanInsert(Comment t)
        {
            _CommentDal.Insert(t);
        }

        public List<Comment> YouCanList()
        {
            return _CommentDal.GetAll();
        }

        public List<Comment> YouCanListById(Expression<Func<Comment, bool>> filter)
        {
            return _CommentDal.GetByIdList(filter);
        }

        public void YouCanUpdate(Comment t)
        {
            _CommentDal.Update(t);
        }
    }
}
