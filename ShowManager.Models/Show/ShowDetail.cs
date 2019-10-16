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
    public class ShowDetail
    {

        public int ShowID { get; set; }
        [Required]
        public string ShowName { get; set; }

        [Required]
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string Location { get; set; }
        public VenueType VenueType { get; set; }
        public Venue Venue { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime DateOfShow { get; set; }

        public List<Artist> ListOfArtist { get; set; }
     //   public string HeadLiningArtist { get; set; }
    }
}
