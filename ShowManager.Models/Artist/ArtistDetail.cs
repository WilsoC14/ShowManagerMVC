using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models
{
    public class ArtistDetail
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string Location { get; set; }
        public List<ShowDetail> ListOfShows {get; set;}
        public List<ArtistListItem> ArtistCommunity { get; set; }
        public List<VenueDetail> VenuesPlayed { get; set; }
    }
}
