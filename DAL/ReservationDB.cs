using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL
{
    public static class ReservationDB
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["ValaisTourism"].ConnectionString;



        public static Reservation GetReservation(int IdReservation)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Reservation WHERE IdReservation= " + IdReservation;
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Reservation reservation = new Reservation()
                            {
                                CheckIn = (DateTime)dr["CheckIn"],
                                CheckOut = (DateTime)dr["CheckOut"],
                                IdReservation = (int)dr["IdReservation"],
                                IdRoom = (int)dr["IdRoom"],
                                ReservationNumber = (int)dr["ReservationNumber"]

                            };

                            return reservation;

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error details " + e);
            }
            return null;
        }

        public static List<Reservation> GetGroupReservation(int ReservationNumber)
        {
            List<Reservation> reservationList = new List<Reservation>();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Reservation WHERE ReservationNumber = " + ReservationNumber;
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Reservation reservation = new Reservation()
                            {
                                CheckIn = (DateTime)dr["CheckIn"],
                                CheckOut = (DateTime)dr["CheckOut"],
                                IdReservation = (int)dr["IdReservation"],
                                IdRoom = (int)dr["IdRoom"],
                                ReservationNumber = (int)dr["ReservationNumber"]
                            };
                            reservationList.Add(reservation);
                        }
                    }
                }

                return reservationList;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error detechted " + e);
            }

            return null;


        }




        public static int CreateReservationNumber(string FullName)
        {
            int reservationNumber = -1;
            //string Name = FirstName + LastName;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Client (FullName) OUTPUT INSERTED.ReservationNumber VALUES(@FullName)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FullName", FullName);
                    //  cmd.Parameters.AddWithValue("@LastName", LastName);
                    cn.Open();

                    reservationNumber = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {

            }
            return reservationNumber;
        }


        public static void CreateReservation(int IdRoom, DateTime CheckIn, DateTime CheckOut, int ResertvationNumber)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Reservation (ReservationNumber, CheckIn, CheckOut,IdRoom) VALUES(@ResertvationNumber,@CheckIn,@CheckOut,@IdRoom)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ReservationNumber", ResertvationNumber);
                    cmd.Parameters.AddWithValue("@CheckIn", CheckIn);
                    cmd.Parameters.AddWithValue("@CheckOut", CheckOut);
                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom);

                    cn.Open();

                    cmd.ExecuteNonQuery();


                }

            }
            catch (Exception e)
            {

            }
        }

    }
}
