
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValais.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel

       
        public static List<Hotel> hotelList = HotelManager.GetAllHotels();

        


        public ActionResult Index()
        {
            // Display All the hotels
            return View(hotelList);
        }

       

    

      
        public ActionResult Details(int IdHotel)
        {
            Hotel hotel = null;

            for(int i=0; i<hotelList.Count; i++)
            {
                if(hotelList.ElementAt(i).IdHotel == IdHotel)
                {
                    hotel = hotelList.ElementAt(i);
                    return View(hotel);
                }
            }
                return View(hotel);
        }
        

      

    }
}