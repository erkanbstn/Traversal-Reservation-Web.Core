using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            _userService = userService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetCommentByDetail();
            return View(values);
        }
        public IActionResult DeleteComment(int id)
        {
            _commentService.YouCanDelete(_commentService.YouCanGetById(id));
            return RedirectToAction("Index");
        }
        public IActionResult CommentDetail(int id)
        {
            var comment = _commentService.YouCanGetById(id);
            ViewBag.user = _userService.YouCanGetById(comment.AppUserId).Name;
            return View(comment);
        }
    }
}
