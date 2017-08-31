using step.Models;
using step.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Routing;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace step.Controllers.Tests
{
    public class OrientationController : Controller
    {
        TestContext db = new TestContext();
        // GET: Orientation
        [Authorize]
        public ActionResult Index()
        {
            var questions = db.OrientationQuestions.Include(q => q.Answers);
            if (questions == null)
                return HttpNotFound();
            return View(questions.ToList());
        }

        [HttpPost]
        public RedirectToRouteResult result(string[] positive, string[] negative)
        {
            int i = 0;
            int work = 0;
            int friend = 0;
            for(int j = 0; j < positive.Length; ++j)
            {
                if(positive[j] == "я")
                {
                    i += 2;
                    if (negative[j] == "д")
                        ++friend;
                    else
                        ++work;
                }

                if (positive[j] == "о")
                {
                    friend += 2;
                    if (negative[j] == "д")
                        ++i;
                    else
                        ++work;
                }

                if (positive[j] == "д")
                {
                    work += 2;
                    if (negative[j] == "я")
                        ++friend;
                    else
                        ++i;
                }
            }
            return RedirectToAction("result", "Orientation", new { i = i, work = work, friends = friend });
        }

        [HttpGet]
        [Authorize]
        public ActionResult result(int i, int work, int friends)
        {
            string message;
            if ((i > work) && (i > friends))
                message = "Направленность на себя (Я)  – ориентация на прямое вознаграждение и удовлетворение безотносительно работы и сотрудников, агрессивность в достижении статуса, властность, склонность к соперничеству, раздражительность, тревожность, интровертированность. ";
            else if ((work > i) && (work > friends))
                message = "Направленность на дело (Д) – заинтересованность в решении деловых проблем, выполнение работы как можно лучше, ориентация на деловое сотрудничество, способность отстаивать в интересах дела собственное мнение, которое полезно для достижения общей цели. ";
            else
                message = "Направленность на общение (О) – стремление при любых условиях поддерживать отношения с людьми, ориентация на совместную деятельность, но часто в ущерб выполнению конкретных заданий или оказанию искренней помощи людям, ориентация на социальное одобрение, зависимость от группы, потребность в привязанности и эмоциональных отношениях с людьми. ";

            ApplicationDbContext context = new ApplicationDbContext();

            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);

            user.OrientationResult = message;

            userManager.Update(user);
            

            ViewBag.message = message;

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult edit(int id)
        {
            var question = db.OrientationQuestions.Include(q => q.Answers).First(q=> q.Id == id);
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult edit(OrientationAnswer[] answers, string question_body, int question_id)
        {
            var question = db.OrientationQuestions.Include(q => q.Answers).First(q => q.Id == question_id);
            question.Body = question_body;
            var answers1 = question.Answers;

            int i = 0;
            foreach (var answer in answers1)
            {
                answer.Attribute = answers[i].Attribute;
                answer.Body = answers[i].Body;
                ++i;
            }
            

            db.SaveChanges();

            return RedirectToAction("index");
        }
        [Authorize(Roles = "admin")]
        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult add(OrientationAnswer[] answers, string question_body)
        {
            var q = db.OrientationQuestions.Add(new OrientationQuestion { Body = question_body });
            for(int i = 0; i < answers.Length; ++i)
            {
                db.OrientationAnswers.Add(new OrientationAnswer { Body = answers[i].Body, Attribute = answers[i].Attribute, OrientationQuestion = q });
            }

            db.SaveChanges();
            return RedirectToAction("index");
        }

        [Authorize(Roles = "admin")]
        public RedirectToRouteResult delete(int id)
        {
            var question = db.OrientationQuestions.Include(q => q.Answers).First(q => q.Id == id);
            foreach (var ansver in question.Answers)
                db.OrientationAnswers.Remove(ansver);
            db.OrientationQuestions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}