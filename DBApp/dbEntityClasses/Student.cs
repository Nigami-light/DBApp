using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.dbEntityClasses
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
