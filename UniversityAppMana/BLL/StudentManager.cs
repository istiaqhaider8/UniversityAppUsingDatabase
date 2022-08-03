using System;
using System.Collections.Generic;
using UniversityAppMana.Models;
using UniversityAppMana.DAL;

namespace UniversityAppMana.BLL
{
    public class StudentManager
    {
        private StudentGateway studentGateway = new StudentGateway(); 

        public int InsertStudent(Student student)
        {
            if(IsRegNoExist(student.RegNo))
            {
                throw new Exception("Registation no aready Exist");
            }
           return studentGateway.InsertStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }

        public Student GetStudentByRegNo(string regNo)
        {
            return studentGateway.GetStudentByRegNo(regNo);
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


