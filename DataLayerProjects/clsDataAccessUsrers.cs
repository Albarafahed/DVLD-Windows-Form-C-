using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerProjects
{
    public class clsDataAccessUsrers
    {
        public static DataTable ListUsers()
        {
            DataTable db = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.UserID,Users.PersonID,People.FirstName +' '+People.SecondName+' '+People.ThirdName+' '+People.LastName AS FullName,
                                 Users.UserName,Users.IsActive
                                 From Users inner join People on Users.PersonID=People.PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                db.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                db = null;
            }
            finally
            {
                connection.Close();
            }
            return db;
        }

       

     
        public static int SaveUser(int PersonID,string UserName, string Password, bool IsActive)
                                
        {
            int Active=IsActive ? 1 : 0;
            int UserId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Users (PersonID,UserName,Password,IsActive)
                            
                        VALUES(@PersonID,@UserName,@Password,@IsActive);
                             
                                 SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
           
           

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                    UserId = id;
            }
            catch (Exception ex)
            {
                UserId = -1;
            }
            finally
            {
                connection.Close();
            }
            return UserId;

        }

        public static bool IsPersonIsUser(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT  1 FROM Users
                                WHERE PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                IsFound = (result != null);


            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetUserByUserID(int UserID, ref int PersonId, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Users Where UserID=@UserId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                   
                    IsFound = true;
                    PersonId = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive =(Boolean) reader["IsActive"];
                  


                }
                else
                    IsFound = false;
                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool GetIDUserByUserName(string UserName, ref int UserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select UserID From Users Where UserName=@UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;
                    UserID = (int)reader["UserID"];
                 
                }
                else
                    IsFound = false;
                reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, int IsActive)                
        {
            bool IsFound = false;
            int Effected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users Set PersonID=@PersonID,UserName=@UserName,Password=@Password,IsActive=@IsActive
                            Where UserID=@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

           
            try
            {
                connection.Open();
                Effected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Effected = 0;
            }
            finally
            {
                connection.Close();
            }
            return Effected > 0;

        }

       public static bool UpdatePassword(int UserID,string Password)
        {
            bool IsFound = false;
            int Effected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users Set Password=@Password
                            Where UserID=@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);
          


            try
            {
                connection.Open();
                Effected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Effected = 0;
            }
            finally
            {
                connection.Close();
            }
            return Effected > 0;

        }

        public static bool DeleteUser(int UserID)
        {
            bool IsFound = false;
            int effected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM Users WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                effected = command.ExecuteNonQuery();

                if (effected > 0)
                {
                    IsFound = true;



                }
                else
                    IsFound = false;


            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
    }
}
