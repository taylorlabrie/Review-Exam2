using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_API
{
    class Results
    {
        //intializing the first two variables on the API page
        public int count { get; set; }
        public string next { get; set; }

        //Creating a list of Result which is the class below
        public List<Result>results { get; set; }

    }

    public class Result
    {
        //Getting the next two variables that are set inside of the first two
        public string name { get; set; }
        public string url { get; set; }

        //Will return the name
        public override string ToString()
        {
            return name;
        }
    }


}
