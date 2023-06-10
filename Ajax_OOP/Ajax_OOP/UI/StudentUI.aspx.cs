using Ajax_OOP.BLL;
using Ajax_OOP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ajax_OOP.UI
{
    public partial class StudentUI : System.Web.UI.Page
    {
        public static StudentManager aManager = new StudentManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Save
        [WebMethod]
        public static string SaveStudent(Students InsertObject)
        {
            return aManager.SaveStudent(InsertObject);
        }
        //AllStudentView
        [WebMethod]
        public static List<Students> DataTablrShow()
        {
            return aManager.GetAllStudentList();
        }
        //Update
        [WebMethod]
        public static string UpdateStudent(Students aStudent)
        {
            return aManager.UpdateStudent(aStudent);
        }
        [WebMethod]
        public static string DeleteStudent(Students aStudent)
        {
            return aManager.StudentDelete(aStudent);
        }


        [WebMethod]
        public static List<Students> Semister()
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Ajax;Integrated Security=True");
            con.Open();
            string Query = "select * from AjaxStudentSemister";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Students> AllSemister = new List<Students>();
            while (dr.Read())
            {
                Students aStudents = new Students();
                aStudents.AutoId = (int)dr["AutoID"];
                aStudents.Semister = dr["Semister"].ToString();

                AllSemister.Add(aStudents);
            }
            return AllSemister;
        }
        //Depatment
        [WebMethod]
        public static List<Students> Depatment()
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Ajax;Integrated Security=True");
            con.Open();
            string Query = "select * from Department";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Students> AllDepartment = new List<Students>();
            while (dr.Read())
            {
                Students aStudents = new Students();
                aStudents.AutoId = (int)dr["AutoID"];
                aStudents.Department = dr["Depatment"].ToString();

                AllDepartment.Add(aStudents);
            }
            return AllDepartment;
        }

        //Subject
        [WebMethod]
        public static List<Students> Subject( Students aSubject)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Ajax;Integrated Security=True");
            con.Open();
            string Query = "select * from Subject where DPid = @dptId ";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@dptId", aSubject.AutoId);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Students> AllDepartment = new List<Students>();
            while (dr.Read())
            {
                Students aStudents = new Students();
                aStudents.AutoId = (int)dr["AutoID"];
                aStudents.Subject = dr["Subject"].ToString();

                AllDepartment.Add(aStudents);
            }
            return AllDepartment;
        }







        //[WebMethod]
        //public static List<Students> Semister()
        //{
        //    return aManager.StudentSemister();
        //}


    }
}