using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public static class HotelDB
    {
        // static connection string for the database connectivity
        private static string connectionString = ConfigurationManager.ConnectionStrings["ValaisTourismLocal"].ConnectionString;


        public static List<Hotel> GetAllHotels()
        {
            List<Hotel> results = null;


            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "Select * From Hotel";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (results == null)
                                results = new List<Hotel>();

                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dataReader["IdHotel"];
                            hotel.Name = (string)dataReader["Name"];
                            hotel.Description = (string)dataReader["Description"];
                            hotel.Location = (string)dataReader["Location"];
                            hotel.Category = (int)dataReader["Category"];
                            hotel.HasWifi = (bool)dataReader["HasWifi"];
                            hotel.HasParking = (bool)dataReader["HasParking"];
                            hotel.Phone = (string)dataReader["Phone"];
                            hotel.Email = (string)dataReader["Email"];
                            hotel.Website = (string)dataReader["Website"];
                            results.Add(hotel);
                        }
                    }

                }

            }

            catch( Exception e)
            {
                throw e;
            }

            return results;
        }

        public static int AddHotel(int IdHotel, string Name, string Description,string Location, int Category, bool HasWifi, bool HasParking,  string Phone, string Email, string Website)
        {
            int result = 0;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Hotel(IdHotel, Name, Description,Location, Category, HasWifi, HasParking, Phone, Email, Website ) values(@IdHotel, @name, @Description, @Location, @Category, @HasWifi, @HasParking, @Phone, @Email, @Website)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", IdHotel);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@Location", Location);
                    cmd.Parameters.AddWithValue("@Category", Category);
                    cmd.Parameters.AddWithValue("@HasWifi", HasWifi);
                    cmd.Parameters.AddWithValue("@HasParking", HasParking);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Website", Website);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            Console.WriteLine("Record is happening");
            return result;
        }

        public static Hotel GetHotel(int IdHotel)
        {
            Hotel hotel = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Hotel where idHotel = @IdHotel";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", IdHotel);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            hotel = new Hotel();

                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Name"] != null)
                                hotel.Name = (string)dr["Name"];

                            if (dr["Description"] != null)
                                hotel.Description = (string)dr["Description"];

                            if (dr["Location"] != null)
                               hotel.Location = (string)dr["Location"];

                            if (dr["HasWifi"] != null)
                                hotel.HasWifi = (bool)dr["HasWifi"];

                            if (dr["HasParking"] != null)
                                hotel.HasParking = (bool)dr["HasParking"];

                        

                            if (dr["Phone"] != null)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Email"] != null)
                                hotel.Email = (string)dr["Email"];
                            if (dr["Website"] != null)
                                hotel.Website = (string)dr["Website"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }

        public static string GetHotelName(int IdHotel)
        {
            string hotelName = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Name FROM Hotel WHERE IdHotel =  " + IdHotel;
                    SqlCommand cmd = new SqlCommand(query, cn);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            hotelName = (string)dr["Name"];
                        }
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured at " + e);
            }

            return hotelName;
        }


        public static Hotel GetHotelUsingStoredProcedure(string Name)
        {
            Hotel hotel = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetHotel", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", Name);
                    

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            hotel = new Hotel();

                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Description"] != null)
                                hotel.Description = (string)dr["Description"];

                            if (dr["Location"] != null)
                                hotel.Location = (string)dr["Location"];

                            if (dr["HasWifi"] != null)
                                hotel.HasWifi = (bool)dr["HasWifi"];

                            if (dr["Email"] != null)
                                hotel.Email = (string)dr["Email"];

                            if (dr["HasParking"] != null)
                             hotel.HasParking = (bool)dr["HasParking"];


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }




        public static int DeleteHotel(int IdHotel, string Name)
        {
            int result = 0;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Hotel Where IdHotel=@IdHotel AND Name = @name";
                    
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", IdHotel);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            Console.WriteLine("Record is Deleted");
            return result;
        }


        public static int DeleteHotel(int IdHotel)
        {
            int result = 0;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Hotel Where IdHotel=@IdHotel";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", IdHotel);
                  
                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            Console.WriteLine("Record is Deleted");
            return result;
        }

    }
}


