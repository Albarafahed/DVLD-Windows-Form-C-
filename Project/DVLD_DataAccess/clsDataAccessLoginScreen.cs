using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDataAccessLoginScreen
    {
        static public bool CheckeUseNameAndPassoredIsFound(string UserName, string Password)
        {
            bool isfound=false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select 1 From Users Where Password=@Password and UserName=@UserName;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                object resul= command.ExecuteScalar();
                isfound=(resul!=null);

            }
            catch (Exception ex) {
                isfound = false;
            }
            finally { connection.Close(); }
            return isfound;
        }

        static public bool CheckeIsActive(string UserName, string Password)
        {
            bool isfound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select 1 From Users Where Password=@Password and UserName=@UserName and IsActive=1;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                object resul = command.ExecuteScalar();
                isfound = (resul != null);

            }
            catch (Exception ex)
            {
                isfound = false;
            }
            finally { connection.Close(); }
            return isfound;
        }
    }
}
