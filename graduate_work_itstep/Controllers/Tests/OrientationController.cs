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
            return View(questions.ToList());
        }

        [HttpPost]
        public RedirectToRouteResult result(string[] positive, string[] negative)
        {
            string str = "";
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
        public string result(int i, int work, int friends)
        {
            ViewBag.i = i;
            ViewBag.work = work;
            ViewBag.friends = friends;
            return "work="+work+" i="+i+" friend="+friends;
        }
    }
}