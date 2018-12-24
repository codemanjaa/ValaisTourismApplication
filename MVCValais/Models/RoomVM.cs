using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCValais.Models
{
    public class RoomVM
    {
        public int IdRoom { get; set; }

        public int IdHotel { get; set; }

        public string HotelName { get; set; }
        public string Location { get; set; }

        public decimal Price { get; set; }

        public string Website { get; set; }

        public List<string> PictureList { get; set; } 

    }
}