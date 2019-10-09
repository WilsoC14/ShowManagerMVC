using ShowManager.Data;
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

        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string Location { get; set; }
        public Data.VenueType VenueType { get; set; }
        public Data.Venue Venue { get; set; }

        public DateTime DateOfShow { get; set; }

        public List<Artist> ListOfArtist { get; set; }

        //   public string HeadLiningArtist { get; set; }

    }
}
