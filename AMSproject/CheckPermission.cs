using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace AMSproject
{
    public class CheckPermission
    {
        public static bool CheckRole(string userId,string roleCiode) 
        {
            string query = $@"SELECT COUNT(*) FROM UserPermissions
                                 INNER JOIN Permission ON Permission.Id = UserPermissions.PermissionId
                                 WHERE UserPermissions.UserId = {Convert.ToInt32(userId)} AND Permission.Number = '{roleCiode}' and Acces = 1";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(GetConnection());
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            con.Open();
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool IsAdmin(string userId)
        {
            string query = $@"SELECT COUNT(*) FROM USERS WHERE ID = {Convert.ToInt32(userId)} AND ISADMIN = 1";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(GetConnection());
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, con);
            con.Open();
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetConnection()
        {
            var configuration = GetConfiguration();
            var a = configuration.GetSection("ConnectionStrings").GetSection("AMSprojectContext").Value;
            return a;
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public static string NumToWord(char[] num)
        {
            return "a";
        }



    }
}
