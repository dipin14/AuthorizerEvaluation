using AuthorizerBLL.Services;
using AuthorizerPresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthorizerPresentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
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
                if(loginObj != null)
                {
                    Session["Username"] = loginObj.UserName.ToString();
                    Session["Role"] = loginObj.Role.ToString();
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ViewBag.Message = "Invalid Credentials";
                }
            }
            return View(loginUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["Username"] != null)
            {
                return View("DashBoard");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
