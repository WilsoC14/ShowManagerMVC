using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models
{
   public class VenueEdit
    {
       // [Key]
        public int VenueID { get; set; }

        public string VenueName { get; set; }

        public Data.VenueType VenueType { get; set; }

        public string Location { get; set; }
        public List<ShowDetail> ListOfShows { get; set; }
    }
}
