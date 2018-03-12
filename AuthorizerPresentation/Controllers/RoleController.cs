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
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            IList<RoleViewModel> roles = _roleService.FindAll().Select(b => new RoleViewModel()
            {
                RoleName = b.RoleName
            }).ToList();
            return View(roles);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoleViewModel roleView)
        {
            _roleService.Create(roleView);
            return RedirectToAction("Index");
        }

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
            _roleService.Update(roleDetails);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string rolename)
        {
            RoleViewModel roleCollection = _roleService.GetByRoleName(rolename);
            return View(roleCollection);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoleViewModel roleDetails, FormCollection requestValidator)
        {
            _roleService.Delete(roleDetails);
            return RedirectToAction("Index");
        }
    }
}
