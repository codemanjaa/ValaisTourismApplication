using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Reservation
    {
        public int IdReservation { get; set; }

        public int ReservationNumber { get; set; }

        public int IdRoom { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

    }
}
