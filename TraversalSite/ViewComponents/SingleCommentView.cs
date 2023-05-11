using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace TraversalSite.ViewComponents
{
    public class SingleCommentView : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public SingleCommentView(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var Comment = _commentService.YouCanGetById(id);
            //var User = _userService.YouCanGetById(Comment.);
            //ViewBag.UserImage = User.Image;
            //ViewBag.UserName = User.Name;
            var comments = _commentService.YouCanListById(b => b.DestinationId == id);
            ViewBag.Yorum = comments.Count;
            return View(comments);
        }
    }
}
