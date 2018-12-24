using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCValais.Models
{
    public class SearchResultVM
    {
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public string Location { get; set; }

        public List<RoomVM> roomVMList { get; set; }
        
    }
}