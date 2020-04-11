﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_API__2
{
    class Results
    {
        public int count { get; set; }
        public string next { get; set; }

        public List<Result>results { get; set; }
    }
    class Result
    {
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
