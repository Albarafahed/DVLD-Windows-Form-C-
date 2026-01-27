using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataLayerProjects
{
    public class clsAccessApplicationTypes
    {

        public static DataTable GetApplicationTypes()
        {
            DataTable dt = new DataTable();

            string query = "SELECT ApplicationTypeID, ApplicationTypeTitle,ApplicationFees FROM ApplicationTypes";

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        // الأفضل تسجيل الخطأ أو رميه
                        throw new Exception("Error loading ApplicationTypes", ex);
                    }
                }
            }

            return dt;
        }

        public static bool GetApplicationByID(int applicationID,ref string applicationTitle,ref double applicationFees)
        {
            bool isFound = false;

            string query = @"SELECT ApplicationTypeTitle, ApplicationFees
                     FROM ApplicationTypes
                     WHERE ApplicationTypeID = @ApplicationID;";

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", applicationID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            applicationTitle =
                                reader["ApplicationTypeTitle"].ToString();

                            applicationFees =
                                Convert.ToDouble(reader["ApplicationFees"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error loading Application Type by ID", ex);
                }
            }

            return isFound;
        }

        public static bool UpdateApplicationTypes(int applicationID, string applicationTitle,  double applicationFees)
        {
            int rowsAffected = 0;
            
            string query = @"Update ApplicationTypes set  ApplicationTypeTitle=@applicationTitle, ApplicationFees=@applicationFees
                    
                     WHERE ApplicationTypeID = @ApplicationID;";

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", applicationID);
                command.Parameters.AddWithValue("@applicationTitle", applicationTitle);
                command.Parameters.AddWithValue("@applicationFees", applicationFees);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                   
                     
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating Application Type", ex);
                }
            }

            return rowsAffected>0;
        }


    }
}
