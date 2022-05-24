using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Clinic.Models
{
    public class CancelApp
    {
        [Required]
        public int PatientID { get; set; }

        public String cnn = "";
        public CancelApp()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }

        public int Cancelpro(CancelApp cat)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Cancelpro", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pat", cat.PatientID);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
       

    }
}