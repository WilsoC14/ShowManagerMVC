using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
    public class ArtistShowData
    {   [Key]
        public int EventID { get; set; }
       // public string EventName { get; set; }
        [ForeignKey("Artist")]  
        public int ArtistID { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public bool IsHeadLiner { get; set; }
        public virtual Artist Artist { get; set; }
        [ForeignKey("Show")]
        public int ShowID { get; set; }
        [Required]
        public string ShowName { get; set; }
        public virtual Show Show { get; set; }
        //[ForeignKey("Venue")]
        //public int VenueID { get; set; }
        //public string VenueName { get; set; }
        //public Venue Venue { get; set; }
    }
}
