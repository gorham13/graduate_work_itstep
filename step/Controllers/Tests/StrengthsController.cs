using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using step.Models;
using step.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace step.Controllers.Tests
{
    public class StrengthsController : Controller
    {
        TestContext db = new TestContext();
        // GET: Strengths
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.keys = db.StrengthTests.ToList();   
            return View();
        }
        [Authorize]
        public ActionResult result(int answer)
        {
            var description = db.StrengthTests.Find(answer).Description;

            ApplicationDbContext context = new ApplicationDbContext();

            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);

            user.StrengthsResult = description;

            userManager.Update(user);

            ViewBag.answer = description;
            return View();
        }
        [Authorize(Roles ="admin")]
        public ActionResult viewAnswers()
        {
            var keys = db.StrengthTests.ToList();
            return View(keys);
        }
        [Authorize(Roles = "admin")]
        public ActionResult edit(int id)
        {
             var key = db.StrengthTests.Find(id);

            return View(key);
        }

        [Authorize(Roles = "admin")]
        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult edit(int id, string description)
        {
            var key = db.StrengthTests.Find(id);
            key.Description = description;
            db.SaveChanges();
            return RedirectToAction("viewAnswers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult add(string description)
        {
            db.StrengthTests.Add(new StrengthTest { Description = description });
            db.SaveChanges();
            return RedirectToAction("viewAnswers");
        }

        [Authorize(Roles = "admin")]
        public RedirectToRouteResult delete(int id)
        {
            var key = db.StrengthTests.Find(id);
            db.StrengthTests.Remove(key);
            db.SaveChanges();

            return RedirectToAction("viewAnswers");
        }
    }
}