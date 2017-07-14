using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace graduate_work_itstep.Models.Tests
{
    public class OrientationQuestion
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public OrientationQuestion()
        {
            Answers = new List<OrientationAnswer>();   
        }

        public virtual ICollection<OrientationAnswer> Answers { get; set; }
    }
}