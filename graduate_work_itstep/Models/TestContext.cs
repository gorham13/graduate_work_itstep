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
        public DbSet<OrientationQuestion> OrientationQuestions { get; set; }
        public DbSet<OrientationAnswer> OrientationAnswers { get; set; }
    }
}