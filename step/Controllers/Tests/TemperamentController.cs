using step.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections;
using step.Models.Tests;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace step.Controllers.Tests
{
    public class TemperamentController : Controller
    {
        TestContext db = new TestContext();
        // GET: Temperament
        [Authorize]
        public ActionResult index()
        {
            var questions = db.TemperamentQuestions.Include(q => q.Temperament);
            return View(questions);
        }

        public ActionResult result(List<int> answers)
        {
            var temperaments = db.Temperaments.ToList();
            int answersCount = 0;
            int[] temperamentId = new int[4];
            
            foreach (var answer1 in answers)
            {
                temperamentId[answer1 - 1]++;
            }
            string s = "";
            foreach (var tmp in temperamentId)
                answersCount += tmp;
            string[] answer = new string[4];
            for (int i = 0; i < temperamentId.Length; ++i)
            {
                answer[i] = (temperamentId[i] * 100 / (float)answersCount) + "% " + temperaments[i].Name;
                s += (temperamentId[i] * 100 / (float)answersCount) + "% " + temperaments[i].Name+"\n";
            }

            ApplicationDbContext context = new ApplicationDbContext();

            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);

            user.TemperamrntResult = s;

            userManager.Update(user);

            ViewBag.answer = answer;
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public ActionResult edit(int id)
        {
            var question = db.TemperamentQuestions.Include(q => q.Temperament).First(q => q.Id == id);
            ViewBag.Temperaments = db.Temperaments.ToList();
            return View(question);
        }

        [HttpPost, ActionName("edit")]
        [ValidateAntiForgeryToken]
        public ActionResult postEdit(string question_body, int temperament_id, int question_id)
        {
            var question = db.TemperamentQuestions.Include(q => q.Temperament).First(q => q.Id == question_id);
            question.Body = question_body;
            question.Temperament = db.Temperaments.First(t => t.Id == temperament_id);

            db.SaveChanges();

            return Redirect("index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult add()
        {
            ViewBag.Temperaments = db.Temperaments.ToList();
            return View();
        }

        [HttpPost, ActionName("add")]
        [ValidateAntiForgeryToken]
        public ActionResult postAdd(string question_body, int temperament_id)
        {
            var question = new TemperamentQuestion();
            question.Body = question_body;
            question.Temperament = db.Temperaments.First(t => t.Id == temperament_id);

            db.TemperamentQuestions.Add(question);
            db.SaveChanges();

            return Redirect("index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult delete(int id)
        {
            var question = db.TemperamentQuestions.First(q => q.Id == id);
            db.TemperamentQuestions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("index"); 
        }
    }
}