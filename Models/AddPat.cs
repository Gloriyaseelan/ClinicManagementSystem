using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class AddPat
    {
        [Required]
        public int PatientID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required(ErrorMessage ="Valid Age")]
        public int Age { get; set; }
        [Required]
        public string DateOfBirth { get; set; }

        public string cnn = "";

        public AddPat()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }

        public int Patpro(AddPat pat)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Patpro", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patfn", pat.FirstName);
            cmd.Parameters.AddWithValue("@patln", pat.LastName);
            cmd.Parameters.AddWithValue("@patsex", pat.Sex);
            cmd.Parameters.AddWithValue("@patage", pat.Age);
            cmd.Parameters.AddWithValue("@patdob", pat.DateOfBirth);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
