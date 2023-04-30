using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace TraversalSite.ViewComponents
{
    public class SingleCommentView : ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentDal());
        UserManager um = new UserManager(new EFUserDal());
        public IViewComponentResult Invoke(int id)
        {
            var Comment = cm.YouCanGetById(id);  
            //var User = um.YouCanGetById(Comment.);
            //ViewBag.UserImage = User.Image;
            //ViewBag.UserName = User.Name;
            var comments = cm.YouCanListById(b => b.DestinationId == id);
            ViewBag.Yorum = comments.Count;
            return View(comments);
        }
    }
}
