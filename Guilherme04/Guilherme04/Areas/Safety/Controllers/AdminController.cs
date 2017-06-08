using Guilherme04.Areas.Safety.Models;
using Guilherme04.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Guilherme04.Areas.Safety.Controllers
{
    public class AdminController : Controller
    {
        #region [Index]
        // GET: Safety/Admin
        public ActionResult Index()
        {
            return View(UsersManagements.Users);
        }
        #endregion [Index]

        #region [Create]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModels model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users { UserName = model.Name, Email = model.Email };
                IdentityResult result = UsersManagements.Create(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        #endregion [Create]

        #region [Edit]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = UsersManagements.FindById(id);
            if(users == null)
            {
                return HttpNotFound();
            }
            var uvm = new UserViewModels();
            uvm.Id = users.Id;
            uvm.Name = users.UserName;
            uvm.Email = users.Email;
            return View(uvm);
        }
        [HttpPost]
        public ActionResult Edit(UserViewModels uvm)
        {
            if (ModelState.IsValid)
            {
                Users users = UsersManagements.FindById(uvm.Id);
                users.UserName = uvm.Name;
                users.Email = uvm.Email;
                users.PasswordHash = UsersManagements.PasswordHasher.HashPassword(uvm.Password);
                IdentityResult result = UsersManagements.Update(users);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(uvm);
        }
        #endregion [Edit]

        #region [Details]
        #endregion [Details]

        #region [Delete]
        #endregion [Delete]

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private UsersManagements UsersManagements
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<UsersManagements>();
            }
        }

    }
}