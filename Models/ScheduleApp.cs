using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class ScheduleApp
    {
        [Required]
        public int PatientID { get; set; }
        [Required]
        public string Specialisation_Required { get; set; }
        [Required]
        public string Doctor { get; set; }
        [Required]
        public String AppointMentDate{get;set;}
        [Required]
        public String AppointmentTime { get; set; }
        public string cnn = "";

        public ScheduleApp()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }

        public int Schedulepro(ScheduleApp sat)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Schedulepro", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patid", sat.PatientID);
            cmd.Parameters.AddWithValue("@spl", sat.Specialisation_Required);
            cmd.Parameters.AddWithValue("@doc", sat.Doctor);
            cmd.Parameters.AddWithValue("@appdate", sat.AppointMentDate);
            cmd.Parameters.AddWithValue("@apptime", sat.AppointmentTime);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
