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

        //HeadLiningArtist probably should be type Artist... leaving it string for now
        public string HeadLiningArtist { get; set; }

        //Icollection stretchgoal
    }
}
