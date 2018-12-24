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
    public class RoomDB
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ValaisTourismLocal"].ConnectionString;

        public static List<Room> GetAllRooms()
        {
            List<Room> results = null;

            

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "Select * From Room";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (results == null)
                                results = new List<Room>();

                            Room room = new Room();

                            room.IdRoom = (int)dataReader["IdHotel"];
                            room.Number = (int)dataReader["Number"];
                            room.Description = (string)dataReader["Description"];
                            room.Type = (int)dataReader["Type"];
                            room.Price = (decimal)dataReader["Price"];
                            room.HasTV = (bool)dataReader["HasTV"];
                            room.HasHairDryer = (bool)dataReader["HasHairDryer"];
                            room.IdHotel = (int)dataReader["IdHotel"];
                            results.Add(room);
                        }
                    }

                }

            }

            catch (Exception e)
            {
                throw e;
            }

            return results;
        }






   
        // Get the room using IdRoom
        public static Room GetRoom(int IdRoom)
        {
            Room room = null;

            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Room where IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != null)
                                room.Number = (int)dr["Number"];

                            if (dr["Description"] != null)
                                room.Description = (string)dr["Description"];
                              

                            if (dr["HasTV"] != null)
                                room.HasTV = (bool)dr["HasTV"];

                            if (dr["HasHairDryer"] != null)
                                room.HasHairDryer = (bool)dr["HasHairDryer"];

                            if (dr["Type"] != null)
                                room.Type = (int)dr["Type"];

                            if (dr["Price"] != null)
                                room.Price = (decimal)dr["Price"];

                            if (dr["IdHotel"] != null)
                                room.IdHotel = (int)dr["IdHotel"];

                            
                            

                        

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return room;
        }



        public static Room GetRoomUsingStoredProcedure(int Number)
        {
            Room room = null;

            string connectionString = ConfigurationManager.ConnectionStrings["ValaisTourism"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetRoom", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Number", Number);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != null)
                                room.Number = (int)dr["Number"];

                            if (dr["Description"] != null)
                                room.Description = (string)dr["Description"];

                            if (dr["HasTV"] != null)
                                room.HasTV = (bool)dr["HasTV"];

                           

                            if (dr["HasHairDryer"] != null)
                                room.HasHairDryer = (bool)dr["HasHairDryer"];


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return room;
        }



        public static List<Room> SerachRoom(DateTime Checkin, DateTime Checkout, string Location)
        {

            List<Room> roomList = new List<Room>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    //  string query = "SELECT * FROM Room " + "WHERE IdHotel = ISNULL(@IdHotel, IdHotel) " +
                    //    "AND IdHotel IN (SELECT IdHotel FROM Hotel WHERE Location = ISNULL(@Location, Location))";


                    string query = "SELECT * FROM Room WHERE IdHotel IN (SELECT IdHotel FROM Hotel WHERE Location = @Location)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                   // cmd.Parameters.AddWithValue("@IdHotel", IdHotel);
                    cmd.Parameters.AddWithValue("@Location", Location);


                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        if(parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                    }
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Room room = new Room();
                            room.IdRoom = (int)dr["IdRoom"];
                            room.HasHairDryer = (bool)dr["HasHairDryer"];
                            room.HasTV = (bool)dr["HasTV"];
                            room.IdHotel = (int)dr["IdHotel"];
                            room.Number = (int)dr["Number"];
                            room.Price = (decimal)dr["Price"];

                            roomList.Add(room);
                        }
                    }
                }
               
            } catch(Exception e)
            {

            }
            return roomList;


        }


        
        /*
        public static List<Room> SearchRoom(DateTime CheckIn, DateTime CheckOut, int? IdHotel, string Location, int? Type, bool? HasHairDryer, bool? HasTV, bool? HasWifi, bool? HasParking, int? Category)
        {
            List<Room> roomList = new List<Room>();

            try
            {
                using(SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Room " +
                                   "WHERE IdHotel =ISNULL(@IdHotel, IdHotel) " +
                                   "AND HasHairDryer = ISNULL(@HasHairDryer, HasHairDryer) " +
                                   "AND HasTV = ISNULL(@HasTV, HasTV) " +
                                   "AND Type >= ISNULL(@Type, Type) " +
                                   "AND IdRoom NOT IN (SELECT IdRoom )";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", IdHotel);
                    cmd.Parameters.AddWithValue("@")
                   
     
                }
                
            }
            catch(Exception e) {
            }

        }

       
        /*
        public static int DeleteRoom(int IdRoom, int Number)
        {
            int result = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["ValaisTourism"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Room Where IdRoom=@IdRoom AND Number = @Number";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", IdRoom);
                    cmd.Parameters.AddWithValue("@Number", Number);
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
        */
    }
}
