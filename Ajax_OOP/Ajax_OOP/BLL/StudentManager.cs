using Ajax_OOP.Connection;
using Ajax_OOP.DAL;
using Ajax_OOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_OOP.BLL
{
    public class StudentManager
    {
        StudentGateway aGateway = new StudentGateway();
        public string SaveStudent(Students aStudents)
        {
            int msg = aGateway.SaveStudent(aStudents);
            if(msg > 0)
            {
                return "Data hass been Saved SuccessFuly.";
            }
            else
            {
                return "Data Notn Saved !";
            }
        }
        //Show DataTable
        public List<Students> GetAllStudentList()
        {
            return aGateway.GetAllStudentList();
        }
        //Update
        public string UpdateStudent(Students aStudents)
        {
            int msg = aGateway.UpdateStudent(aStudents);
            if( msg > 0)
            {
                return "Student Update Successfuly.";
            }
            else
            {
                return "Student Not Update !";
            }
        }
        //DeletStudent
        public string StudentDelete(Students aStudents)
        {
            int msg = aGateway.StudentDelete(aStudents);
            if(msg > 0)
            {
                return "Student Delete Successfully";
            }
            else
            {
                return "Student Not Delete";
            }
        }
        ////Semister
        //public List<Students> StudentSemister()
        //{
        //    return aGateway.StudentSemister();
        //}



    }
}