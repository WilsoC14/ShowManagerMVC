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
   //     private readonly Guid _userID;
        //public VenueService(Guid userID)
        //{
        //    _userID = userID;
        //}
        public VenueService ()
        { }

        //Crud
        public bool CreateVenue(VenueCreate model)
        {
            var entity = new Venue()
            {
              //  UserID = _userID,
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

        //crUd
        public bool UpdateVenue(VenueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {                           //Add e.OwnerID == _userID so only venue user or admin can delete after adding user roles
                var entity = ctx.Venues.Single(e => e.VenueID == model.VenueID) ;
                entity.VenueName = model.VenueName;
                entity.VenueType = model.VenueType;
                entity.Location = model.Location;

                return ctx.SaveChanges() == 1;

                    }
        }

        //cruD
        public bool DeleteVenue(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venues                 //Add e.OwnerID == _userID so only venue user or admin can delete after adding user roles
                        .Single(e => e.VenueID == venueId);
                ctx.Venues.Remove(entity);
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
                    VenueID = entity.VenueID,
                    VenueName = entity.VenueName,
                    VenueType = entity.VenueType,
                    Location = entity.Location
                };
                }

                
}

    }
}
