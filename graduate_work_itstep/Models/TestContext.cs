using graduate_work_itstep.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace graduate_work_itstep.Models
{
    public class TestContext : DbContext
    {
        public DbSet<LifeValuesAnswer> LifeValuesAnswers { get; set; }
        public DbSet<LifeValuesKey> LifeValuesKeys { get; set; }
        public DbSet<LifeValuesQuestion> LifeValuesQuestions { get; set; }
        public DbSet<OrientationQuestion> OrientationQuestions { get; set; }
        public DbSet<OrientationAnswer> OrientationAnswers { get; set; }

    }


    public class TestDbInitializer : DropCreateDatabaseAlways<TestContext>
    {
        protected override void Seed(TestContext db)
        {
            var q = db.OrientationQuestions.Add(new OrientationQuestion {Body = "Наибольшее удовлетворение я получаю от:" });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Одобрения моей работы; ", Attribute = "я", OrientationQuestion = q });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Сознания того, что работа сделана хорошо; ", Attribute = "д", OrientationQuestion = q });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Сознания того, что меня окружают друзья. ", Attribute = "о", OrientationQuestion = q });

            q = db.OrientationQuestions.Add(new OrientationQuestion { Body = "Если бы я играл в футбол (волейбол, баскетбол), то я хотел бы быть:" });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Тренером, который разрабатывает тактику игры; ", Attribute = "д", OrientationQuestion = q });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Известным игроком; ", Attribute = "я", OrientationQuestion = q });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Выбранным капитаном команды. ", Attribute = "о", OrientationQuestion = q });

            q = db.OrientationQuestions.Add(new OrientationQuestion { Body = "По-моему, лучшим педагогом является тот, кто: " });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Проявляет интерес к учащимся и к каждому имеет индивидуальный подход; ", Attribute = "я", OrientationQuestion = q });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Вызывает интерес к предмету так, что учащиеся с удовольствием углубляют свои знания в этом предмете; ", Attribute = "д", OrientationQuestion = q });
            db.OrientationAnswers.Add(new OrientationAnswer { Body = "Создает в коллективе такую атмосферу, при которой никто не боится высказать свое мнение. ", Attribute = "о", OrientationQuestion = q });


            db.LifeValuesAnswers.Add(new LifeValuesAnswer { Body = "їсти" });
            db.LifeValuesAnswers.Add(new LifeValuesAnswer { Body = "спати" });
            db.LifeValuesAnswers.Add(new LifeValuesAnswer { Body = "грошей" });
            db.LifeValuesAnswers.Add(new LifeValuesAnswer { Body = "морозива" });

            db.LifeValuesQuestions.Add(new LifeValuesQuestion { Body = "Я неодмінно повинен" });
            db.LifeValuesQuestions.Add(new LifeValuesQuestion { Body = "Жахливо якщо" });
            db.LifeValuesQuestions.Add(new LifeValuesQuestion { Body = "Я не можу терпіти" });

            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 1, QuestionId = 1, Description = "Я неодмінно повинен їсти" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 2, QuestionId = 1, Description = "Я неодмінно повинен спати" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 3, QuestionId = 1, Description = "Я неодмінно повинен грошей" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 4, QuestionId = 1, Description = "Я неодмінно повинен морозива" });

            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 1, QuestionId = 2, Description = "Жахливо якщо їсти" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 2, QuestionId = 2, Description = "Жахливо якщо спати" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 3, QuestionId = 2, Description = "Жахливо якщо грошей" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 4, QuestionId = 2, Description = "Жахливо якщо морозива" });

            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 1, QuestionId = 3, Description = "Я не можу терпіти їсти" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 2, QuestionId = 3, Description = "Я не можу терпіти спати" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 3, QuestionId = 3, Description = "Я не можу терпіти грошей" });
            db.LifeValuesKeys.Add(new LifeValuesKey { AnswerId = 4, QuestionId = 3, Description = "Я не можу терпіти морозива" });



            base.Seed(db);
        }
    }

}