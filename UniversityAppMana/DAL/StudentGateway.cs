using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityAppMana.Models;
using UniversityAppMana.Models.ViewModel;

namespace UniversityAppMana.DAL
{
    public class StudentGateway:Gateway
    {
   
        public int InsertStudent(Student student)
        {
           
            string query = "Insert into Students(Name,RegNo,Email,Address,DepartmentId) VALUES('" + student.Name + "','" + student.RegNo + "','" + student.Email + "','" + student.Address + "','" + student.DepartmentId + "');";
            Connecction.Open();
            Command.CommandText = query;
            int rowAffected = Command.ExecuteNonQuery();
            Connecction.Close();
            return rowAffected;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();
            string query = "Select * from Students;";
            Command.CommandText = query;
            Connecction.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string regNo = reader["RegNo"].ToString();
                string address = reader["Address"].ToString();
                int depatmentId = Convert.ToInt32(reader["DepartmentId"]);
                Student student = new Student(id,name, email, regNo, address,depatmentId);
                studentList.Add(student);
            }

            reader.Close();
            Connecction.Close();
            return studentList;
        }

        public Student GetStudentByRegNo(string regNo)
        {
            string query = "Select * from Students where RegNo='" + regNo + "';";
            Command.CommandText = query;
            Connecction.Open();
            Student student = null;
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string regNumber = reader["RegNo"].ToString();
                string address = reader["Address"].ToString();
                int depatmentId = Convert.ToInt32(reader["DepartmentId"]);
                reader.Close();
                student = new Student(id,name, email, regNumber, address,depatmentId);
            }

            Connecction.Close();
            return student;
        }

        public int Update(Student student)
        {
            string query = "UPDATE  Students SET Name='" + student.Name + "',RegNo='" + student.RegNo + "',Email='" + student.Email + "',Address='" + student.Address + "',DepartmentId='" + student.DepartmentId + "' WHERE Id=" + student.Id+"";
            Command.CommandText = query;
            Connecction.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connecction.Close();
            return rowAffected;
        }

        public List<StudentViewModel> GetAllStudentViewModels()
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            string query = "select * from VW_GetAllStudentInfo";
            Command.CommandText = query;
            Connecction.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string regNo = reader["RegNo"].ToString();
                string address = reader["Address"].ToString();
                int depatmentId = Convert.ToInt32(reader["DepartmentId"]);
                string departmentName = reader["DepartmentName"].ToString();
                StudentViewModel student = new StudentViewModel();
                student.Id = id;
                student.Name = name;
                student.Email = email;
                student.RegNo = regNo;
                student.Address = address;
                student.DepartmentId = depatmentId;
                student.DepartmentName = departmentName;
                studentList.Add(student);
            }

            reader.Close();
            Connecction.Close();
            return studentList;
        }
    }


}
