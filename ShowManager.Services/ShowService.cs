using ShowManager.Data;
using ShowManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Services
{
   public class ShowService
    {
        private readonly Guid _userID;
        public ShowService(Guid userID)
        {
            _userID = userID;
        }

        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Shows.Select(e => new ShowListItem
                {
                    ShowID = e.ShowID,
                    ShowName = e.ShowName,
                    Venue = e.Venue,
                    VenueID = e.VenueID,
                    VenueName = e.VenueName,
                    VenueType = e.VenueType,
                    Location = e.Location,
                    Artist = e.Artist,
                    ArtistID = e.ArtistID,
                    ArtistName = e.ArtistName,

                });
                return query.ToList();
            }
        }

    }
}
