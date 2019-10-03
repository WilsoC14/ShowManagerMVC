using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models
{
   public class ShowListItem
    {
        public int ShowID { get; set; }
        [Required]
        public string ShowName { get; set; }
        [Required]
       // [ForeignKey("Venue")]
        public int VenueID { get; set; }
        public string VenueName { get; set; }

        public string Location { get; set; }
        public Data.VenueType VenueType { get; set; }

        public Data.Venue Venue { get; set; }
        //[Required]
        //[ForeignKey("Artist")]
        //public string ArtistName { get; set; }
        //public int ArtistID { get; set; }

        //public Data.Artist Artist { get; set; }
        public string HeadLiningArtist { get; set; }
    }
}
