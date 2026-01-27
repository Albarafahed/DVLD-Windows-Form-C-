using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Net;
using System.Security.Policy;

namespace DataLayerProjects
{
    public class clsDataLayer
    {
        public static DataTable ListPeople()
        {
            DataTable db = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName,
                         People.SecondName,People.ThirdName,People.LastName,
	                      case
	                      When People.Gendor=0 Then 'Male'
	                      When People.Gendor=1 Then 'Female'
	                       else 'Unknown'
	                        end As Gender,
                             People.DateOfBirth,Countries.CountryName as Nationality,People.Phone,People.Email 
                             FROM People inner join Countries on People.NationalityCountryID=Countries.CountryID";
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

        public static DataTable GetCountryName()
        {
            DataTable db = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Select CountryName From Countries";
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

        public static bool IsFound(string NationalNo)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT  NationalNo FROM People
                                WHERE NationalNO=@NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static int SavePepole(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                   int Gendor, DateTime DateOfBirth, string Phone, int NationalityCountryID, string Address,
                                   string ImagePath, string Email)
        {
            int PersonId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,
                             Gendor,Address, Phone, Email, NationalityCountryID,ImagePath)
                        VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,
                             @Gendor,@Address, @Phone, @Email, @NationalityCountryID,@ImagePath);
                                 SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email == "")
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                    PersonId = id;
            }
            catch (Exception ex)
            {
                PersonId = -1;
            }
            finally
            {
                connection.Close();
            }
            return PersonId;

        }

        public static bool UpdatePeploe(int PersonId, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                   int Gendor, DateTime DateOfBirth, string Phone, int NationalityCountryID, string Address,
                                   string ImagePath, string Email)
        {
            bool IsFound = false;
            int Effected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People Set NationalNo=@NationalNo,FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName
                            ,LastName=@LastName,DateOfBirth=@DateOfBirth,
                             Gendor=@Gendor,Address=@Address, Phone=@Phone, 
                            Email=@Email, NationalityCountryID=@NationalityCountryID,ImagePath=@ImagePath
                        Where PersonId=@PersonId;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email == "")
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

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

        public static bool GetPeopleByPersonID(int PersonId, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
                           ref int Gendor, ref DateTime DateOfBirth, ref string Phone, ref int NationalityCountryID, ref string Address,
                           ref string ImagePath, ref string Email)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From People Where PersonId=@PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    Gendor = int.Parse(reader["Gendor"].ToString());
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Phone = (string)reader["Phone"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    Address = (string)reader["Address"];
                    ImagePath = (string)reader["ImagePath"];
                    if (reader["Email"] == DBNull.Value)
                        Email = "";
                    else
                        Email = (string)reader["Email"];


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

        public static int GetPeopleByPersonID(int PersonId)
        {
            int personId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select PersonId From People Where PersonId=@PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    personId = id;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return personId;
        }
        public static int GetPeopleByNationalNo(string NationalNo)
        {
            int personId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select PersonId From People Where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    personId = id;
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }
            return personId;
        }

        public static bool DeletePeople(int PersonId)
        {
            bool IsFound = false;
            int effected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM People WHERE PersonId=@PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);

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

    

    public static string GetCountry(int CountryId)
        {
            string CountryName = string.Empty;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select CountryName From Countries WHERE CountryID= @CountryId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryId", CountryId);



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    CountryName = result.ToString();
            }
            catch (Exception ex)
            {
                CountryName = "";
            }
            finally
            {
                connection.Close();
            }
            return CountryName;

        } 
    }
    }

