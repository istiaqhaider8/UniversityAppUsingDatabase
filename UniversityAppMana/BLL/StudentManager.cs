using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityAppMana.Models;

namespace UniversityAppMana.BLL
{
    public class StudentManager
    {
        string connectionString = @"Server = DESKTOP-CAJ7GNM; database = UniversityBD_29; Integrated Security = true";
        public int InsertStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Insert into Students(Name,RegNo,Email,Address) VALUES('" + student.Name + "','" + student.RegNo +
                           "','" + student.Email + "','" + student.Address + "');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Students;";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string regNo = reader["RegNo"].ToString();
                string address = reader["Address"].ToString();
                Student student = new Student(name, email, regNo, address);
                studentList.Add(student);
            }

            reader.Close();
            connection.Close();
            return studentList;
        }

        public Student GetStudentByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Students where RegNo='" + regNo + "';";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            Student student = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string regNumber = reader["RegNo"].ToString();
                string address = reader["Address"].ToString();
                reader.Close();
                student = new Student(name, email, regNumber, address);
            }

            connection.Close();
            return student;
        }

        public bool IsRegNoExist(string regNo)
        {
            bool isRegNoExist = false;
            Student student = GetStudentByRegNo(regNo);
            if (student != null)
            {
                isRegNoExist = true;
            }

            return isRegNoExist;
        }
    }
}


