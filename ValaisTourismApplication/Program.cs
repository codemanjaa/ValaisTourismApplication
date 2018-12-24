using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DTO;


namespace ValaisTourismApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of Hotels");
            HotelManager hotelManager = new HotelManager();
            List<Hotel> hotelList = hotelManager.GetAllHotels();

            RoomManager roomManager = new RoomManager();
            List<Room> roomList = roomManager.GetAllRooms();

            PictureManager pictureManager = new PictureManager();
            List<Picture> pictureList = pictureManager.GetAllPictures();



            // Display the options for the user testing purpose only


            Console.WriteLine("---------------Valais Tourism Booking ---------------------------");
            Console.WriteLine("Please select the following options using their repsective number");

            Console.WriteLine("1 - Get All Hotels");
            Console.WriteLine("2 - Add Hotel");
            Console.WriteLine("3 - Update Hotel ");
            Console.WriteLine("4 - Remove Hotel");
            Console.WriteLine("5 - List All Data");

            Console.WriteLine("-------------------------------------------------" +
                "---------------------");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Console.Write("am i here...");
                for (int i = 0; i < hotelList.Count; i++)
                {
                    Console.WriteLine(hotelList[i].IdHotel + " is the " + hotelList[i].Name);
                    Console.ReadLine();

                }
            }

            else if (input == 2)
            {
                Console.Write("Enter the Hotel ID ");
                int IdHotel = int.Parse(Console.ReadLine());

                Console.Write("Enter the Hoted name ");
                string Name = Console.ReadLine();


                Console.Write("Enter the description ");
                string Description = Console.ReadLine();

                Console.Write("Enter the location ");
                string Location = Console.ReadLine();

                Console.Write("Enter the category ");
                int Category = int.Parse(Console.ReadLine());


                Console.WriteLine("Does hotel have wifi? ");
                bool HasWifi = (bool.Parse(Console.ReadLine()));
                Console.WriteLine("Does hotel have parking? ");
                bool HasParking = bool.Parse(Console.ReadLine());
                Console.WriteLine("Enter the phone number");
                string Phone = Console.ReadLine();
                Console.WriteLine("Enter the email ");
                string Email = Console.ReadLine();
                Console.WriteLine("Website ");
                string Website = Console.ReadLine();


                hotelManager.AddHotel(IdHotel, Name, Description, Location, Category, HasWifi, HasParking, Phone, Email, Website);
                Console.ReadLine();

            }

            else if (input == 3)
            {
                Console.WriteLine("See you in the next version");
                Console.ReadLine();
            }


            else if (input == 4)
            {
                Console.Write("Enter the Hoted ID ");
                int IdHotel = int.Parse(Console.ReadLine());

                Console.Write("Enter the Hoted name ");
                string Name = Console.ReadLine();

                hotelManager.DeleteHotel(IdHotel, Name);
                Console.ReadLine();

            }



           


            //

            else if (input == 5)
            {

                for (int i = 0; i < hotelList.Count; i++)
                {
                    Console.WriteLine(hotelList[i].IdHotel + " is the " + hotelList[i].Name);

                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(roomList.Count + " room available");
                for (int i = 0; i < roomList.Count; i++)
                {
                    Console.WriteLine(roomList[i].IdRoom + "has " + roomList[i].HasHairDryer);
                }


                Console.WriteLine("------------------------------------------");
                Console.WriteLine(pictureList.Count + " pictures available");
                for (int i = 0; i < pictureList.Count; i++)
                {
                    Console.WriteLine(pictureList[i].IdRoom + "has " + pictureList[i].Url);
                }
                Console.WriteLine("Press any key to continue");
                //Console.ReadKey();
                Console.ReadLine();
                Console.WriteLine("-----------Adding the record-------------------------------");
                //  hotelManager.AddHotel();


                Console.ReadLine();

                Console.WriteLine("-----------Getting the record-------------------------------");
                Hotel hotel = hotelManager.GetHotel(10);
                Console.WriteLine(hotel.IdHotel + " is located in " + hotel.Location);
                Console.ReadLine();

                Console.WriteLine("----------Getting the Hotel using Stored Procedure-------------------------------");
                hotel = hotelManager.GetHotelUsingStoredProcedure("Mayura Palace");
                Console.WriteLine(hotel.IdHotel + " is located in " + hotel.Location);
                Console.ReadLine();
            }
        }
    }
}
