using System;
using System.Collections.Generic;
using UniversityAppMana.BLL;
using UniversityAppMana.Models;
using UniversityAppMana.Models.ViewModel;


namespace UniversityAppMana.UI
{
    public partial class StudentEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["regNo"] != null)
                {
                    string regNo = Request.QueryString["regNo"];
                    Student student = studentManager.GetStudentByRegNo(regNo);
                    if (student != null)
                    {
                        nameTextBox.Text = student.Name;
                        emailTextBox.Text = student.Email;
                        regNoTextBox.Text = student.RegNo;
                        addressTextBox.Text = student.Address;
                        StudentIdHiddenField.Value = student.Id.ToString();
                        departmetDropDownList.SelectedIndex = student.DepartmentId;
                        SaveButton.Text = "Update";
                    }
                }
                ShowStudents();
                LoadDepartmentDropdown();
            }
        }


        StudentManager studentManager = new StudentManager();

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameTextBox.Text;
                string email = emailTextBox.Text;
                string regNo = regNoTextBox.Text;
                string address = addressTextBox.Text;
                int departmentId = Convert.ToInt32(departmetDropDownList.SelectedValue);
                Student student = new Student(name, email, regNo, address,departmentId);

                int rowAffected = 0;

                if (SaveButton.Text == "Update")
                { 
                    int studentId = Convert.ToInt32(StudentIdHiddenField.Value); 
                    student.Id = studentId;
                   rowAffected = studentManager.Update(student);
                   if (rowAffected > 0)
                   {
                       Response.Write("Update Successfully");
                       nameTextBox.Text = "";
                       emailTextBox.Text = "";
                       regNoTextBox.Text = "";
                       addressTextBox.Text = "";
                       ShowStudents();
                    }
                   else
                   {
                       Response.Write("Update Failed");
                   }
                }
                else
                {
                    rowAffected = studentManager.InsertStudent(student);
                    if (rowAffected > 0)
                    {
                        Response.Write("Save Successfully");

                        nameTextBox.Text = "";
                        emailTextBox.Text = "";
                        regNoTextBox.Text = "";
                        addressTextBox.Text = "";
                        ShowStudents();
                    }
                    else
                    {
                        Response.Write("Insertion Failed!");
                    }
                }
            }
            catch(Exception exception)
            {
                Response.Write(exception.Message);
            }
        }
        protected void ShowButton_Click(object sender, EventArgs e)
        {
            ShowStudents();
        }
        private void ShowStudents()
        {
            List<StudentViewModel> studentList = studentManager.GetStudentViewModels();


            studentGridView.DataSource = studentList;
            studentGridView.DataBind();
        }


        private void LoadDepartmentDropdown()
        {
            DepartmentManager departmentManager = new DepartmentManager();
            List<Department> departments = departmentManager.GetAllDepartments();
            departmetDropDownList.DataSource = departments;
            departmetDropDownList.DataTextField = "Name";
            departmetDropDownList.DataValueField = "Id";
            departmetDropDownList.DataBind();
        }
    }
}