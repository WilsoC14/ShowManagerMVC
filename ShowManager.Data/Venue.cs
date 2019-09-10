using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
    public enum VenueType { New = 1, LongStanding, Temporary,}
    class Venue
    {
        [Key]
       public int VenueID { get; set; }
        public string VenueName { get; set; }
        public VenueType VenueType { get; set; }
        public string Location { get; set; }
        


    }
}
