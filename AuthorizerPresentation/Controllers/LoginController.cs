using AuthorizerBLL.Services;
using AuthorizerPresentation.ViewModels;
using Common.DataTransferObjects;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthorizerPresentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public LoginController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {                                
                var loginObj = _userService.Login(loginUser);

                //Successful login
                if(loginObj != null)
                {
                    Session["Username"] = loginObj.UserName.ToString();
                    getPriveleges(loginObj);

                    FormsAuthentication.SetAuthCookie(loginObj.UserName.ToString(), loginUser.RememberMe);
                    return RedirectToAction("UserDashBoard");
                }
                //Unsuccessful login
                else
                {
                    ViewBag.Message = "Invalid Credentials";
                }
            }
            return View(loginUser);
        }

        /// <summary>
        /// Signing out of user
        /// </summary>
        /// <returns></returns>
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            Session.Abandon();
            return View("Login");
        }

        /// <summary>
        /// User home page
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UserDashBoard()
        {
            try
            {
                if (Session["Username"] != null)
                {
                    return View("UserDashBoard");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch
            {
                return RedirectToAction("Login");
            }
        }

        /// <summary>
        /// Gets individual page priveleges for role
        /// </summary>
        /// <param name="loginObj"></param>
        protected void getPriveleges(UserDTO loginObj)
        {
            var priveleges = _roleService.GetPagePriveleges(loginObj.RoleId);
            if (priveleges != null)
            {
                Session["PageA"] = priveleges.AccessToPageA;
                Session["PageB"] = priveleges.AccessToPageB;
                Session["PageC"] = priveleges.AccessToPageC;
            }
            else
            {
                Session["PageA"] = Session["PageB"] = Session["PageC"] = false;
            }
        }
    }
}
