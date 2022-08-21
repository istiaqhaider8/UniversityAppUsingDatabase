using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityAppMana.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Code { get; set; }

        public Department(int id, string name, string code)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
        }
    }
}