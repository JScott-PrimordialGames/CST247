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
        string querry = @"if exists(select * from Test.dbo.Users where username = @Username and password = @Password collate SQL_Latin1_General_CP1_CS_AS)
                                        Begin
                                            select 'true'
                                        End
                                        Else
                                        Begin
                                            select 'false'
                                        End";
        public bool FindByUser(UserModel user)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            SqlCommand command = new SqlCommand(querry, con);
              
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);

            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader[0].ToString() == "true")
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
            
        }

    }

}