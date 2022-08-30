using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityAppMana.DAL;
using UniversityAppMana.Models;

namespace UniversityAppMana.BLL
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway = new DepartmentGateway();
        public List<Department> GetAllDepartments()
        {
            return departmentGateway.getAllDepartments();
        }
    }
}