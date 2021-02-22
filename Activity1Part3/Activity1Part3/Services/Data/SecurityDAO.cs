using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Activity1Part3.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(Activity1Part3.Models.UserModel user)
        {
            SqlConnection conn = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; database=Test; integrated security = SSPI");
            SqlCommand cmnd = new SqlCommand("SELECT * FROM Users WHERE Username = '" + user.Username + "' AND Password = '" + user.Password + "'", conn);

            conn.Open();
            SqlDataReader reader = cmnd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}