﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotnetWebAPI.Models
{
    public class EmployeeV2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}