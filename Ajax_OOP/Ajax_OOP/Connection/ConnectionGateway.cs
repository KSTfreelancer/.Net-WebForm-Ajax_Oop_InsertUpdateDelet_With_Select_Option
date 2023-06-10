using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ajax_OOP.Connection
{
    public class ConnectionGateway
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Ajax_OOPname"].ConnectionString;

        
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public int RowCount { get; set; }

        public string Query { get; set; }

        public ConnectionGateway()
        {
            //Connection = new ConfigurationManager.ConnectionStrings["Ajax_OOPname"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandTimeout = 10000;
        }
    }
}