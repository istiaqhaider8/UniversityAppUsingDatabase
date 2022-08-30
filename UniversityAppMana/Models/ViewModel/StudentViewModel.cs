using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityAppMana.Models.ViewModel
{
    public class StudentViewModel
    {
        public int Id { set; get; }
        public string RegNo { set; get; }
        public string Email { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public int DepartmentId { set; get; }
        public string DepartmentName { set; get; }

        

    }
}