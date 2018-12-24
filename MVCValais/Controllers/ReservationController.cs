using DTO;
using BLL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValais.Controllers
{
    public class ReservationController : Controller
    {
        static ReservationManager reservationManager = new ReservationManager();
       // Reservation resrevationList = reservationManager.GetReservation();
        // GET: Reservation
        public ActionResult Index()
        {
        


                return View();
        }
    }
}