using DTO;
using BLL;
using MVCValais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValais.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
       

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Result(DateTime Checkin, DateTime Checkout, string Location)
        {

            //ViewBag.Checkin = Checkin;
            // ViewBag.Checkout = Checkout;


            if ((Checkin == Checkout) || (Checkin < DateTime.Now) || (Checkin > Checkout))
            {

                //ViewBag.Message = "Check the date";
                return RedirectToAction("Index", "Search");
                
            }
            else 
            {


                // string Locationsel = Request.Form["Location"].ToString();

                // Search the room for the locataion in the database



                List<Room> roomList = RoomManager.SearchRoom(Checkin, Checkout, Location);
               
                List<RoomVM> roomVMList = new List<RoomVM>();
               
                foreach(Room room in roomList)
                {
                    int IdHotel = (int)room.IdHotel;
                    Hotel hotel = HotelManager.GetHotel(IdHotel);
                    int IdRoom = (int)room.IdRoom;
                    List<string> PictureList = PictureManager.GetPictures(IdRoom);

                    roomVMList.Add(new RoomVM()
                    {
                        IdRoom = room.IdRoom,
                        IdHotel = room.IdHotel,
                        Website = hotel.Website,
                        HotelName = hotel.Name,
                        Price = room.Price,
                        PictureList = PictureList

                    });
                }


                SearchResultVM searchResult = new SearchResultVM()
                {
                    Checkin = Checkin,
                    Checkout = Checkout,
                    Location = Location,
                    roomVMList = roomVMList
                };
                
                return View(searchResult);
            }


        }

       
    }
}