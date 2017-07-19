using graduate_work_itstep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections;

namespace graduate_work_itstep.Controllers.Tests
{
    public class TemperamentController : Controller
    {
        TestContext db = new TestContext();
        // GET: Temperament
        public ActionResult Index()
        {
            var questions = db.TemperamentQuestions.Include(q => q.Temperament);
            return View(questions);
        }

        public ActionResult result(List<int> answers)
        {
            var temperaments = db.Temperaments.ToList();
            int answersCount = 0;
            int[] temperamentId = new int[4];
            string s = "";
            foreach (var answer in answers)
                temperamentId[answer-1]++;

            foreach (var tmp in temperamentId)
                answersCount += tmp;

            for (int i = 0; i < temperamentId.Length; ++i)
                s += (temperamentId[i] * 100 / (float)answersCount) + "%" + temperaments[i].Name+"<br>";
            return Content(s);
        }
    }
}