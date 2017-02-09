using System.Web.Mvc;
using asp_mvc_2.Security;
using System.Web.Security;
using asp_mvc_2.Models.ViewModel;
using asp_mvc_2.Models.EntityManager;
namespace asp_mvc_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }

        [AuthorizeRoles("Admin","Manager")]
        public ActionResult AdminOnly()
        {
            return View();
        }
        public ActionResult UnAuthorized()
        {
            return View();
        }

        [AuthorizeRoles("Admin")]
        public ActionResult ManageUserPartial()
        {
            if (User.Identity.IsAuthenticated)
            {
                string loginName = User.Identity.Name;
                UserManager UM = new UserManager(); UserDataView UDV = UM.GetUserDataView(loginName);
                return PartialView(UDV);
            }
            return View();
        }

    }
}