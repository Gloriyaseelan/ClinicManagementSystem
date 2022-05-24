using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;

using System.Data.Sql;
using System.Data.SqlClient;
namespace Clinic.Models
{
    public class Login
    {
        
        [Required(ErrorMessage="Valid Username")]
        public String UserName { get; set; }
        
       [Required(ErrorMessage ="Valid Password")]
        public String Passcode { get; set; }
        public string cnn = "";
        public Login()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }
        public int validation(Login log)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Userpro", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User", log.UserName);
            cmd.Parameters.AddWithValue("@pass", log.Passcode);
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);
            con.Close();
            return (0);
        }
    }
}
