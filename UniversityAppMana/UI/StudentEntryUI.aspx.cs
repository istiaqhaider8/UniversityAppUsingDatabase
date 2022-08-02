using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UniversityAppMana.Models;


namespace UniversityAppMana.UI
{
    public partial class StudentEntryUI : System.Web.UI.Page
    {
        string connectionString = @"Server = DESKTOP-1ACAIOK; database = UniversityBD_29; Integrated Security = true";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string regNo = regNoTextBox.Text;
            string address = addressTextBox.Text;
            Student student = new Student(name, email, regNo, address);

            bool isRegNoExist = IsRegNoExist(student.RegNo);
            if (isRegNoExist)
            {
                Response.Write("Registration number already exist");
            }
            else
            {
                int rowAffected = InsertStudent(student);

                if (rowAffected > 0)
                {
                    Response.Write("Save Successfully");
                }
                else
                {
                    Response.Write("Insertion Failed!");
                }
            }
        }


        protected void ShowButton_Click(object sender, EventArgs e)
        {
            ShowStudents();
        }


        private int InsertStudent(Student student)
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


        private void ShowStudents()
        {
            List<Student> studentList = GetAllStudents();


            studentGridView.DataSource = studentList;
            studentGridView.DataBind();
        }

        private List<Student> GetAllStudents()
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

        private Student GetStudentByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Students where RegNo='"+regNo+"';";
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

        private bool IsRegNoExist(string regNo)
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