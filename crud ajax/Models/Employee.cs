using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_ajax.Models
{
    public class Employee
    {
        public int employeeid { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string state { get; set; }

        public string country { get; set; }
    }
}