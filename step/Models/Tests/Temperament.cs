using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace step.Models.Tests
{
    public class Temperament
    {   
        public int Id { get; set; }
        public string Name { get; set; }

        public Temperament()
        {
            Questions = new List<TemperamentQuestion>();
        }

        public virtual ICollection<TemperamentQuestion> Questions { get; set; }
    }
}