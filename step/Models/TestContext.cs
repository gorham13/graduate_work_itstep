using step.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace step.Models
{
    public class TestContext : DbContext
    {

	    public TestContext(): base("DefaultConnection"){}

        public DbSet<LifeValuesAnswer> LifeValuesAnswers { get; set; }
        public DbSet<LifeValuesKey> LifeValuesKeys { get; set; }
        public DbSet<LifeValuesQuestion> LifeValuesQuestions { get; set; }
        public DbSet<OrientationQuestion> OrientationQuestions { get; set; }
        public DbSet<OrientationAnswer> OrientationAnswers { get; set; }
        public DbSet<Temperament> Temperaments { get; set; }
        public DbSet<TemperamentQuestion> TemperamentQuestions { get; set; }
        public DbSet<StrengthTest> StrengthTests { get; set; }


    }


    public class TestDbInitializer : DropCreateDatabaseIfModelChanges<TestContext>
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


            var h = db.Temperaments.Add(new Temperament { Name = "Холерик" });
            var f = db.Temperaments.Add(new Temperament { Name = "Флегматик" });
            var m = db.Temperaments.Add(new Temperament { Name = "Меланхолік" });
            var s = db.Temperaments.Add(new Temperament { Name = "Санглвінік" });

            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я суетлив и неусидчив.", Temperament = h});
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я несдержан и вспыльчив.", Temperament = h });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я нетерпелив.", Temperament = h });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я резок и прямолинеен в общении.", Temperament = h });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я часто являюсь инициатором всевозможных мероприятий.", Temperament = h });

            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я – жизнерадостный человек.", Temperament = s });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я энергичен и всегда знаю, куда направить свою энергию.", Temperament = s });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я не всегда довожу до конца то, что начал.", Temperament = s });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я часто себя переоцениваю.", Temperament = s });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Все новое я схватываю буквально на лету.", Temperament = s });

            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Обычно я спокоен и хладнокровен.", Temperament = f });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Во всех своих делах я придерживаюсь определенной последовательности.", Temperament = f });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Обычно я рассудителен и осторожен.", Temperament = f });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я спокойно переношу ожидание.", Temperament = f });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Если мне нечего сказать, я предпочитаю молчать.", Temperament = f });

            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я застенчив и стеснителен.", Temperament = m });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "В незнакомой обстановке я чувствую себя растерянным.", Temperament = m });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Мне трудно заговорить с незнакомым человеком.", Temperament = m });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Порой я не верю в свои силы.", Temperament = m });
            db.TemperamentQuestions.Add(new TemperamentQuestion { Body = "Я спокойно переношу одиночество.", Temperament = m });


            db.StrengthTests.Add(new StrengthTest { Description = "1 тип — «руководитель»\nОбычно это люди,имеющие склонность к руководящей и организаторской деятельности.Ориентированы на социально - значимые нормы поведения, могут обладать даром хороших рассказчиков, основывающимся на высоком уровне речевого развития.Обладают хорошей адаптацией в социальной сфере, доминирование над другими удерживают в определенных границах.Нужно помнить, что проявление данных качеств зависит от уровня психического развития.При высоком уровне развития индивидуальные черты развиты, реализуемы, достаточно хорошо осознаются.При низком уровне развития могут не выявляться в профессиональной деятельности, а присутствовать ситуативно, хуже, если неадекватно ситуациям.Это относится ко всем характеристикам." });
            db.StrengthTests.Add(new StrengthTest
            {
                Description = "2 тип — «ответственный исполнитель»\n Обладает многими чертами типа «руководитель», однако в принятии ответственных решений часто присутствуют колебания.Данный тип людей более ориентирован на «умение делать дело», высокий профессионализм,обладает высоким чувством ответственности и требовательности к себе и другим, высоко ценит правоту, т.е.характеризуется повышенной чувствительностью к правдивости.Часто они страдают соматическими заболеваниями нервного происхождения как следствие перенапряжения."
            });

            base.Seed(db);
        }
    }

}