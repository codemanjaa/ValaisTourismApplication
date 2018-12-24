using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BLL
{
    public class ReservationManager
    {
        public Reservation GetReservation(int IdReservation)
        {
           return DAL.ReservationDB.GetReservation(IdReservation);
        }
    }
}
