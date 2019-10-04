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
        public virtual Venue Venue { get; set; }

        public string HeadLiningArtist { get; set; }

        //Icollection stretchgoal
    }
}
