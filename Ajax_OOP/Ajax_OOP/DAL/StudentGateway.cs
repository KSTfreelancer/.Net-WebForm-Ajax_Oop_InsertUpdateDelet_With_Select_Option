using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax_OOP.Connection;
using Ajax_OOP.Model;
using Ajax_OOP.DAL;
using System.Data.SqlClient;
using System.Data;


namespace Ajax_OOP.DAL
{
    public class StudentGateway:ConnectionGateway
    {
       
        public int SaveStudent(Students aStudents)
        {
            if(Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            int msg;
            try
            {
                Query = "insert into AjaxStudent values(@name,@roll,@reg,@dep,@sbj,@smtr,@sft,@add,@exit)";
                Command = new SqlCommand(Query,Connection);
                Command.Parameters.AddWithValue("@name", aStudents.Name);
                Command.Parameters.AddWithValue("@roll", aStudents.Roll);
                Command.Parameters.AddWithValue("@reg", aStudents.RegNo);
                Command.Parameters.AddWithValue("@dep", aStudents.Department);
                Command.Parameters.AddWithValue("@sbj", aStudents.Subject);
                Command.Parameters.AddWithValue("@smtr", aStudents.Semister);
                Command.Parameters.AddWithValue("@sft", aStudents.Shift);
                Command.Parameters.AddWithValue("@add", aStudents.Admission);
                Command.Parameters.AddWithValue("@exit", aStudents.Farewell);
                msg = Command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                msg = -1;
            }
            if(Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            return msg;
        }
        //DataTabel Show
        public  List<Students> GetAllStudentList()
        {
            List<Students> AllStudent = new List<Students>();

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            try
            {
                 Query = "select * from AjaxStudent order by AutoId";
                Command = new SqlCommand(Query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Students aStudent = new Students();
                    aStudent.AutoId = (Int32)Reader["AutoId"];
                    aStudent.Roll = (Int32)Reader["Roll"];
                    aStudent.RegNo = (Int32)Reader["reg"];
                    aStudent.Name = (string)Reader["StudentName"];
                    aStudent.Department = (string)Reader["Department"];
                    aStudent.Subject = (string)Reader["Subject"];
                    aStudent.Semister = (string)Reader["Semister"];
                    aStudent.Shift = (string)Reader["Shift"];
                    aStudent.Admission = (string)Reader["Admission"];
                    aStudent.Farewell = (string)Reader["Farewell"];

                    AllStudent.Add(aStudent);
                }
            }
            catch
            {

            }
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            return AllStudent;

        }
        //Update
        public int UpdateStudent(Students aStudents)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            int msg;
            try
            {
                Query = "UPDATE AjaxStudent SET StudentName =@name,Roll=@roll,reg=@reg,Department=@dep,Subject=@sbj,Semister=@smt,Shift=@sft,Admission=@add,Farewell=@exit WHERE AutoId=@id";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@name",aStudents.Name);
                Command.Parameters.AddWithValue("@roll", aStudents.Roll);
                Command.Parameters.AddWithValue("@reg", aStudents.RegNo);
                Command.Parameters.AddWithValue("@dep", aStudents.Department);
                Command.Parameters.AddWithValue("@sbj", aStudents.Subject);
                Command.Parameters.AddWithValue("@smt", aStudents.Semister);
                Command.Parameters.AddWithValue("@sft", aStudents.Shift);
                Command.Parameters.AddWithValue("@add", aStudents.Admission);
                Command.Parameters.AddWithValue("@exit", aStudents.Farewell);
                Command.Parameters.AddWithValue("@id", aStudents.AutoId);
                msg = Command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                msg = -1;
            }
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            return msg;

        }
        //Delet
        public int StudentDelete(Students aStudents)
        {

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            int msg;
            try
            {
                Query = "DELETE FROM AjaxStudent WHERE AutoId=@id";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@id", aStudents.AutoId);
                msg = Command.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                msg = -1;
            }
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            return msg;
        }
        ////Semister
        //public List<Students> StudentSemister()
        //{
        //    List<Students> AllSemister = new List<Students>();
        //    if (Connection.State == ConnectionState.Closed)
        //    {
        //        Connection.Open();
        //    }
        //    try
        //    {
        //        Query = "select * from AjaxStudentSemister";
        //        Command = new SqlCommand(Query, Connection);
        //        Reader = Command.ExecuteReader();
        //        while (Reader.Read())
        //        {
        //            Students aStudents = new Students();
        //            aStudents.AutoId = (Int32)Reader["AutoID"];
        //            aStudents.Semister = (string)Reader["Semister"];

        //            AllSemister.Add(aStudents);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    if (Connection.State == ConnectionState.Open)
        //    {
        //        Connection.Close();
        //    }
        //    return AllSemister;

        //}



    }
}


















