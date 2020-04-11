using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set;}
        public double Salary { get; set; }

        public Employee()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Gender = string.Empty;
            Salary = 0;

        }

        public Employee(string first, string last, string email, string gender, string salary)
        {
            FirstName = first;
            LastName = last;
            Email = email;
            Gender = gender;
            Salary = Convert.ToDouble(salary.Replace("$", ""));
        }

        public override string ToString()
        {
            return ($"{FirstName} {LastName} ({Gender}) makes {Salary.ToString("c2")} and can be contacted at {Email}");
        }
    }
    
}
