using AuthorizerBLL.Services;
using AuthorizerPresentation.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AuthorizerPresentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            IList<UserViewModel> users = _userService.FindAll().Select(b => new UserViewModel(){
                FirstName = b.FirstName,
                LastName = b.LastName,
                Password = b.Password,
                UserName = b.UserName,
                UserRole = b.Role
            }).ToList();
            return View(users);
        }
        public ActionResult Create()
        {
            FetchRoles();
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel userView)
        {
            var a = userView.UserRole.RoleName;        

            _userService.Create(userView);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userCollection = _userService.GetByUserName(username);
            if(userCollection == null)
            {
                return HttpNotFound();
            }
            FetchRoles();
            return View(userCollection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userDetails, FormCollection requestValidator)
        {            
            _userService.Update(userDetails);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string username)
        {
            UserViewModel userCollection = _userService.GetByUserName(username);
            return View(userCollection);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserViewModel userDetails, FormCollection requestValidator)
        {
            _userService.Delete(userDetails);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Fetches list of all roles and saves to ViewData["Roles"]
        /// </summary>
        private void FetchRoles()
        {
            ViewData.Clear();

            //Obtaining list of roles
            var roleList = _roleService.FindAll().ToList();

            //Saving to viewdata for populating combo box
            ViewData["Roles"] = new SelectList(roleList.Select(r => r.RoleName), "roleName");
        }
    }
}
