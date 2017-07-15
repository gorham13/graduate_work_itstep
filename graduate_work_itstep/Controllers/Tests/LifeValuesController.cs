using graduate_work_itstep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace graduate_work_itstep.Controllers.Tests
{
    public class LifeValuesController : Controller
    {
        TestContext db = new TestContext();
        // GET: LifeValues
        public ActionResult Index()
        {
            var answers = db.LifeValuesAnswers.ToList();
            var questions = db.LifeValuesQuestions.ToList();

            ViewBag.answers = answers;
            ViewBag.questions = questions;

            return View();
        }
        [HttpPost]
        public ActionResult result(int answers)
        {
            string s = answers.ToString();
            //for (int i = 0; i < answers.Length; ++i)
            //    s += answers[i] + " ";

            return Content(s);
        }
    }
}