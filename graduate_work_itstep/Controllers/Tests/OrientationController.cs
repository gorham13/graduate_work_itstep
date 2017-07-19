using graduate_work_itstep.Models;
using graduate_work_itstep.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Routing;

namespace graduate_work_itstep.Controllers.Tests
{
    public class OrientationController : Controller
    {
        TestContext db = new TestContext();
        // GET: Orientation
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
        public ActionResult result(int i, int work, int friends)
        {
            string message;
            if ((i > work) && (i > friends))
                message = "Направленность на себя (Я)  – ориентация на прямое вознаграждение и удовлетворение безотносительно работы и сотрудников, агрессивность в достижении статуса, властность, склонность к соперничеству, раздражительность, тревожность, интровертированность. ";
            else if ((work > i) && (work > friends))
                message = "Направленность на дело (Д) – заинтересованность в решении деловых проблем, выполнение работы как можно лучше, ориентация на деловое сотрудничество, способность отстаивать в интересах дела собственное мнение, которое полезно для достижения общей цели. ";
            else
                message = "Направленность на общение (О) – стремление при любых условиях поддерживать отношения с людьми, ориентация на совместную деятельность, но часто в ущерб выполнению конкретных заданий или оказанию искренней помощи людям, ориентация на социальное одобрение, зависимость от группы, потребность в привязанности и эмоциональных отношениях с людьми. ";

            ViewBag.message = message+"/n"+" i="+i + " work=" + work + " friends=" + friends;
            return View();
        }
    }
}