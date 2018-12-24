using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;


namespace BLL
{
    public class HotelManager
    {

        public static List<Hotel> GetAllHotels()
        {
            return DAL.HotelDB.GetAllHotels();
        }

        //Test data 
        public int AddHotel()
        {
           return HotelDB.AddHotel(11, "Mayura Palace", "Paradise","Sion", 1, true, true, "0000000", "sma@baira.com", "www.ttt.com");
        }

        public void AddHotel(int IdHotel, string Name, string Description, string Location, int Category, bool HasWifi, bool HasParking, string Phone, string Email, string Website)
        {
            HotelDB.AddHotel( IdHotel,  Name,  Description,  Location,  Category,  HasWifi,  HasParking,Phone,Email,Website);
            Console.Write("Record added");
        }

        public static Hotel GetHotel(int IdHotel)
        {
            return HotelDB.GetHotel(IdHotel);
        }

        public Hotel GetHotelUsingStoredProcedure(string Name)
        {
            return HotelDB.GetHotelUsingStoredProcedure(Name);
        }


        public static string GetHotelName(int IdHotel)
        {
            return HotelDB.GetHotelName(IdHotel);
        }

       
    }
}
