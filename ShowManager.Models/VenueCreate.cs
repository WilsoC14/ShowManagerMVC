﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models
{
    public class VenueCreate
    {
        public string VenueName { get; set; }
        public Data.VenueType VenueType { get; set; }
        public string Location { get; set; }
    }
}
