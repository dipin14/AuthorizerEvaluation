using AuthorizerBLL.Services;
using AuthorizerPresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AuthorizerPresentation.Controllers
{
    [Authorize(Roles ="admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Retrieves all roles list and displays in grid
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Mapping RoleDTO list to RoleViewModel list
            IList<RoleViewModel> roles = _roleService.FindAll().Select(b => new RoleViewModel()
            {
                RoleName = b.RoleName,
                AccessToPageA = b.AccessToPageA,
                AccessToPageB = b.AccessToPageB,
                AccessToPageC = b.AccessToPageC
            }).ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creating new Role using RoleViewModel
        /// </summary>
        /// <param name="roleView"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(RoleViewModel roleView)
        {
            if (roleView != null)
            {
                roleView.RoleName.Trim();
                var createResult = _roleService.Create(roleView);
                if (createResult == -1)
                {
                    ModelState.AddModelError("RoleName", "Role Name Already Exists");
                    return View(roleView);
                }
                else if (createResult == 0)
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

        /// <summary>
        /// Editing existing role
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public ActionResult Edit(string rolename)
        {
            if (rolename == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModel roleCollection = _roleService.GetByRoleName(rolename);
            if (roleCollection == null)
            {
                return HttpNotFound();
            }
            return View(roleCollection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleViewModel roleDetails, FormCollection requestValidator)
        {
            try
            {
                _roleService.Update(roleDetails);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("RoleName", "Please enter non-existing Role Name");
                return View(roleDetails);
            }
        }

        /// <summary>
        /// Deleting role
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public ActionResult Delete(string rolename)
        {
            if (rolename == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                RoleViewModel roleCollection = _roleService.GetByRoleName(rolename);
                if (HttpContext.User.IsInRole(rolename))
                {
                    ViewBag.Error = "Cannot delete your current role";
                    return View();
                }
                else
                {
                    return View(roleCollection);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoleViewModel roleDetails, FormCollection requestValidator)
        {
            if (roleDetails == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                _roleService.Delete(roleDetails);
                return RedirectToAction("Index");
            }
        }
    }
}
