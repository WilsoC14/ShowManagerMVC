using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
    public class Show
    {
        [Key]
        public int ShowID { get; set; }
        [Required]
        public string ShowName { get; set; }
        [Required]
        [ForeignKey("Venue")]
        public int VenueID { get; set; }
        public string VenueName { get; set; }

        public string Location { get; set; }
        public VenueType VenueType { get; set; }

        public Venue Venue { get; set; }
        [Required]
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        
        public Artist Artist { get; set; }
        public string HeadLiningArtist { get; set; }
    }
}
