﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace graduate_work_itstep.Models.Tests
{
    public class TemperamentQuestion
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public virtual Temperament Temperament { get; set; }
    }
}