﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room
    {
        public int IdRoom { get; set; }
        public int Number { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public decimal Price { get; set; }

        public bool HasTV { get; set; }
        public bool HasHairDryer { get; set; }
        public int IdHotel { get; set; }

        public override string ToString()
        {
            return "IdRoom " + IdRoom +
                    "Number" + Number +
                     "Type " + Type +
                      "Description " + Description +
                       "Price " + Price +
                       "HasTV " + HasTV +
                       "HasHairDryer" + HasHairDryer +
                      
                       "IdHotel" + IdHotel;

        }

    }

    
}
