using graduate_work_itstep.Models;
using graduate_work_itstep.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace graduate_work_itstep.Controllers.Tests
{
    public class OrientationController : Controller
    {
        TestContext db = new TestContext();
        // GET: Orientation
        public ActionResult Index()
        {
            

            var questions = db.OrientationQuestions;
            var answers = db.OrientationAnswers;
            ViewBag.answers = answers;
            return View(questions);
        }
    }
}