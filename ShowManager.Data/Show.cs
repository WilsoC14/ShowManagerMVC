using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
    class Show
    {
        [Key]
        public int ShowID { get; set; }
        [Required]
        public string ShowName { get; set; }
        [Required]
        [ForeignKey("Venue")]
        public string VenueLocation { get; set; }
        public Venue Venue { get; set; }
        [Required]
        [ForeignKey("Artist")]
        public string HeadLiningArtist { get; set; }
        public Artist Artist { get; set; }
    }
}
