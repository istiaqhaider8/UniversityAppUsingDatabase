using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityAppMana.Models;

namespace UniversityAppMana.DAL
{

    public class DepartmentGateway
    { 
       string connectionString = @"Server = DESKTOP-1ACAIOK; database = UniversityBD_29; Integrated Security = true";

       public List<Department> getAllDepartments()
       {
           List<Department> departments = new List<Department>();
           SqlConnection connection = new SqlConnection(connectionString);
           string quray = "select * from Departments";
           SqlCommand command = new SqlCommand(quray, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   int id = Convert.ToInt32(reader["id"]);
                   string name = reader["Name"].ToString();
                   string code = reader["code"].ToString();
                   Department department = new Department(id, name, code);
                   departments.Add(department);
               }
               reader.Close();
           }
           connection.Close();
           return departments;
       }


    }
}