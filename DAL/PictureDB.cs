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
    public class PictureDB
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ValaisTourismLocal"].ConnectionString;

        public static List<Picture> GetAllPicures()
        {
            List<Picture> results = null;

            //string connectionstring = ConfigurationManager.ConnectionStrings["ValaisToursim"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * from Picture";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            if (results == null)
                                results = new List<Picture>();

                            Picture picture = new Picture();
                            picture.IdPicture = (int)dataReader["IdPicture"];
                            picture.Url = (string)dataReader["Url"];
                            picture.IdRoom = (int)dataReader["IdRoom"];
                            results.Add(picture);

                        }
                    }
                }


            }
            catch(Exception e)
            {
                throw e;
            }
            return results;

        }



        public static List<string> GetPictures(int IdRoom)
        {
            List<string> pictureList = new List<string>();

            try
            {
                using(SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Url FROM Picture WHERE IdRoom = @IdRoom";
                    
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom);
                    cn.Open();

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string url = (string)dr["Url"];
                            pictureList.Add(url);
                        }
                    }
                }

            }
            catch (Exception e)
            {

            }
            return pictureList;

        }

    }
}
