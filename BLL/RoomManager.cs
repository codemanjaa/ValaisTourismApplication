using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;



namespace BLL
{
    public class RoomManager
    {
        public static List<Room> GetAllRooms()
        {
            return DAL.RoomDB.GetAllRooms();

        }

        public static Room GetRoom(int IdRoom)
        {
            return DAL.RoomDB.GetRoom(IdRoom);
        }

        public static List<Room> SearchRoom(DateTime Checkin, DateTime Checkout, string Location)
        {
            return DAL.RoomDB.SerachRoom(Checkin, Checkout, Location);
        }




/*
        public static List<Room> SearchRoom(DateTime CheckIn, DateTime CheckOut, int? IdHotel, string Location, int? Type, bool? HasHairDryer, bool? HasTV, bool? HasWifi, bool? HasParking, int? Category)
        {



        }

    */
    }
}
