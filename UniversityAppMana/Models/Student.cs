using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityAppMana.Models
{
    public class Student
    {
        public string RegNo { set; get; }
        public string Email { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }



        public Student(string name, string email, string regNo, string address)
        {
            this.Name = name;
            this.Email = email;
            this.RegNo = regNo;
            this.Address = address;
        }
    }
}