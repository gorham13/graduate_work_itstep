using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using step.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace step.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();
            var users = userManager.Users.ToList();

            //user.OrientationResult = message;

            //userManager.Update(user);
            return View(users);
        }

        [Authorize(Roles = "admin")]
        public ActionResult user(string id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(id);

            return View(user);
        }
    }
}