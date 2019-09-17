using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models
{
    public class VenueListItem
    {
        public int VenueID { get; set; }

        public string VenueName { get; set; }

        public Data.VenueType VenueType { get; set; }

        public string Location { get; set; }
    }
}
