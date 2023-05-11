using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        private readonly IReservationService _reservationService;

        public UserController(IUserService userService, ICommentService commentService, IReservationService reservationService)
        {
            _userService = userService;
            _commentService = commentService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _userService.YouCanList();
            return View(values);
        }
        public IActionResult UserComment(int id)
        {
            var values = _commentService.TGetCommentByUser(id);
            return View(values);
        }
        public IActionResult UserReservation(int id)
        {
            var values = _reservationService.TGetListByUsers(id);
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            _userService.YouCanDelete(_userService.YouCanGetById(id));
            return RedirectToAction("Index");
        }
    }
}
