using AuthorizerBLL.Services;
using AuthorizerPresentation.ViewModels;
using Common.DataTransferObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AuthorizerPresentation.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        /// <summary>
        /// Display list of users
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var userDtoList = _userService.FindAll();

            if (userDtoList != null)
            {
                //Mapping UserDto to UserViewModel
                IList<UserViewModel> users = userDtoList.Select(b => new UserViewModel()
                {
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                    Password = b.Password,
                    UserName = b.UserName,
                    RoleId = b.RoleId,
                    RoleName = FetchRoles(b.RoleId)
                }).ToList();
                return View(users);
            }
            else
            {
                return View();
            }
            
        }

        //Create a new user
        public ActionResult Create()
        {
            ViewData["Roles"] = FetchRoles();
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel userView)
        {
            if (userView != null)
            {
                //Refreshes roles to DropDown on the case that duplicate username error occurs
                ViewData["Roles"] = FetchRoles();

                userView.FirstName.Trim();
                var userCreateResult = _userService.Create(userView);

                if (userCreateResult == -1)
                {
                    ModelState.AddModelError("UserName", "User Name Already Exists");
                    return View(userView);
                }
                else if (userCreateResult == 0)
                {
                    ViewBag.Message = "Db Creation Error! Please Restart Application";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        //Edit existing user
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
            ViewData["Roles"] = FetchRoles();
            return View(userCollection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userDetails, FormCollection requestValidator)
        {            
            _userService.Update(userDetails);
            return RedirectToAction("Index");
        }

        //Delete a user
        public ActionResult Delete(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                UserViewModel userCollection = _userService.GetByUserName(username);
                if (HttpContext.User.Identity.Name == username)
                {
                    ViewBag.Error = "Cannot delete yourself";
                    return View();
                }
                else
                {
                    return View(userCollection);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserViewModel userDetails, FormCollection requestValidator)
        {
            if (userDetails == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                _userService.Delete(userDetails);
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Fetches list of all roles and saves to ViewData["Roles"]
        /// </summary>
        private SelectList FetchRoles()
        {
            ViewData.Clear();

            //Obtaining list of roles
            var roleList = _roleService.FindAll().ToList();

            //Setting to select list for populating combo box
            return new SelectList(roleList, "roleId", "roleName");
        }

        //Fetches role based on id
        private string FetchRoles(int id)
        {
            ViewData.Clear();

            //Obtaining list of roles
            var roleList = _roleService.FindAll().ToList();

            return roleList.Where(r => r.RoleId == id).Select(r => r.RoleName).First();
        }
    }
}
