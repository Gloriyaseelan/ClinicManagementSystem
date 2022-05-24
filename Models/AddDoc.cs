using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class AddDoc
    {
        [Required]
        //public int DoctorID { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Specialisation { get; set; }
        [Required]
        public String VisitingHours { get; set; }
        public string cnn = "";

        public  AddDoc()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }
        
        public int Docpro(AddDoc Doc)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Docpro", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@docfn", Doc.FirstName);
            cmd.Parameters.AddWithValue("@docln", Doc.LastName);
            cmd.Parameters.AddWithValue("@docsex", Doc.Sex);
            cmd.Parameters.AddWithValue("@docspl", Doc.Specialisation);
            cmd.Parameters.AddWithValue("@doctime", Doc.VisitingHours);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
