using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
    public enum VenueType { New = 1, LongStanding, Temporary,}
   public class Venue
    {
        
        public Guid UserID { get; set; }
        [Key]
       public int VenueID { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public VenueType VenueType { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
