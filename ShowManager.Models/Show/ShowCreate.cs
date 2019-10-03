using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models
{
    public class ShowCreate
    {
        public string ShowName { get; set; }
        //[ForeignKey("Venue")]
        public int VenueID { get; set; }
       // public string VenueName { get; set; }
       // public string Location { get; set; }
        //VenueType will be determined after VenueID links to existing venue... same with other parameters
   //     public Data.Venue Venue { get; set; }
        //[ForeignKey("Artist")]
        //public int ArtistID { get; set; }
        //public string ArtistName { get; set; }
        
        //public Data.Artist Artist { get; set; }
        // is this where determine headliner and such?
        // maybe create a list of artist... even though it won't be in my database?
        

    }
}
