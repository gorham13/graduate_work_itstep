using step.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace step.Controllers.Tests
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
        public ActionResult result(int[] answers, int[] questions)
        {
            string testKeys = "";
            for (int i = 0; i < answers.Length; ++i)
            {
                int answer = answers[i];
                int question = questions[i];
                var Keys = db.LifeValuesKeys
                    .Where(k => k.AnswerId == answer)
                    .FirstOrDefault(k => k.QuestionId == question);
                if (Keys != null)
                    testKeys += Keys.Description.ToString() + "<br>";
            }
                

            return Content(testKeys);
        }
    }
}