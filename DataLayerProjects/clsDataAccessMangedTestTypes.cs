using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerProjects
{
    public class clsDataAccessMangedTestTypes
    {
        public static DataTable GetMangedTestTypes()
        {
            DataTable dt = new DataTable();

            string query = "SELECT TestTypeID, TestTypeTitle,TestTypeDescription,TestTypeFees FROM TestTypes";

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

        public static bool GetTestTypesByID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescription, ref double TestTypeFees)
        {
            bool isFound = false;

            string query = @"SELECT TestTypeTitle, TestTypeDescription,TestTypeFees
                     FROM TestTypes
                     WHERE TestTypeID = @TestTypeID;";

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            TestTypeTitle =
                                reader["TestTypeTitle"].ToString();
                            TestTypeDescription =
                                reader["TestTypeDescription"].ToString();

                            TestTypeFees =
                                Convert.ToDouble(reader["TestTypeFees"]);
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

        public static bool UpdateTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, double TestTypeFees)
        {
            int rowsAffected = 0;

            string query = @"Update TestTypes set  TestTypeTitle=@TestTypeTitle, TestTypeFees=@TestTypeFees,TestTypeDescription=@TestTypeDescription
                    
                     WHERE TestTypeID = @TestTypeID;";

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
                command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);

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

            return rowsAffected > 0;
        }
    }
}
