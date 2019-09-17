using ShowManager.Data;
using ShowManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Services
{
    public class VenueService
    {
        private readonly Guid _userID;
        public VenueService(Guid userID)
        {
            _userID = userID;
        }

        //Crud
        public bool CreateVenue(VenueCreate model)
        {
            var entity = new Venue()
            {
                UserID = _userID,
                VenueName = model.VenueName,
                VenueType = model.VenueType,
                Location = model.Location
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Venues.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<VenueListItem> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Venues.Select(e => new VenueListItem
                {
                    VenueID = e.VenueID,
                    VenueName = e.VenueName,
                    VenueType = e.VenueType,
                    Location = e.Location
                });
                return query.ToList();
            }
        }

        //Helper
        public VenueDetail GetVenueByID(int id)
        {
            using (var ctx = new ApplicationDbContext())

            { var entity = ctx.Venues.Single(e => e.VenueID == id);
                return new VenueDetail
                {

                }
}

    }
}
