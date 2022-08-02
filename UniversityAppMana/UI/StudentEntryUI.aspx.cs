using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityAppMana.BLL;

using UniversityAppMana.Models;


namespace UniversityAppMana.UI
{
    public partial class StudentEntryUI : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        StudentManager studentManager = new StudentManager();

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string regNo = regNoTextBox.Text;
            string address = addressTextBox.Text;
            Student student = new Student(name, email, regNo, address);

            bool isRegNoExist = studentManager.IsRegNoExist(student.RegNo);
            if (isRegNoExist)
            {
                Response.Write("Registration number already exist");
            }
            else
            {
                int rowAffected = studentManager.InsertStudent(student);

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
        private void ShowStudents()
        {
            List<Student> studentList = studentManager.GetAllStudents();


            studentGridView.DataSource = studentList;
            studentGridView.DataBind();
        }




    }
}