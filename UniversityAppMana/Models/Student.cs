using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityAppMana.Models
{
    public class Student
    {
        public int Id { set; get; }
        public string RegNo { set; get; }
        public string Email { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public int DepartmentId { set; get; }





        public Student(string name, string email, string regNo, string address,int departmentId)
        {
            this.Name = name;
            this.Email = email;
            this.RegNo = regNo;
            this.Address = address;
            this.DepartmentId = departmentId;

        }

        public Student(int id, string name, string email, string regNo, string address, int departmentId) :this(name,email,regNo,address, departmentId)
        {
            this.Id = id;
        }
    }
}