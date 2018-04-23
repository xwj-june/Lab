﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        //Prop + tab  to simplify create a get&set method 
        //public int MyProperty { get; set; }
    }
}
