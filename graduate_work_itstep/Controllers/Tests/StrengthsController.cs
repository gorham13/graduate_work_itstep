using graduate_work_itstep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace graduate_work_itstep.Controllers.Tests
{
    public class StrengthsController : Controller
    {
        TestContext db = new TestContext();
        // GET: Strengths
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult result(int answer)
        {
            var description = db.StrengthTests.Find(answer).Description;
            return Content(description);
        }

    }
}