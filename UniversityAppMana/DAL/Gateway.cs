using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityAppMana
{
    public class Gateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["UniversityDBconnectionStrings"].ConnectionString;


        public Gateway()
        {
            Connecction = new SqlConnection(connectionString);
            Command = new SqlCommand();
            Command.Connection = Connecction;
        }

        protected SqlConnection Connecction { get; set; }
        protected SqlCommand Command { get; set; }


    }
}