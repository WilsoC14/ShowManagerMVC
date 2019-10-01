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
                    //Artist = e.Artist,
                    //ArtistID = e.ArtistID,
                    //ArtistName = e.ArtistName,

                });
                return query.ToList();
            }
        }

        public ShowDetail GetShowByID(int id)
        {
            using (var ctx = new ApplicationDbContext())

            {
                var entity = ctx.Shows.Single(e => e.ShowID == id);
                return new ShowDetail
                {
                    ShowID = entity.ShowID,
                    ShowName = entity.ShowName,
                    Venue = entity.Venue,
                    VenueID = entity.VenueID,
                    VenueName = entity.VenueName,
                    VenueType = entity.VenueType,
                    Location = entity.Location,
                  ////  Artist = entity.Artist,
                  //  ArtistID = entity.ArtistID,
                  //  ArtistName = entity.ArtistName,
                };
            }
        }
        public bool CreateShow(ShowCreate model)
        {
            var entity = new Show()
            {
                ShowName = model.ShowName,
                Venue = model.Venue,
                VenueID = model.VenueID,
                VenueName = model.VenueName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;

            }

        }

        public bool UpdateShow (ShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {   //Not entirely clear how I will manage the Artists properties of a Show
                var entity = ctx.Shows.Single(e => e.ShowID == model.ShowID);
                entity.ShowName = model.ShowName;
                entity.Venue = model.Venue;
             //   entity.Artist = model.Artist;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShow(int showID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows                 //Add e.OwnerID == _userID so only venue user or admin can delete after adding user roles
                        .Single(e => e.ShowID == showID);
                ctx.Shows.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Add EXISTING artist to artistShowData
        // 
        public bool AddShowToArtistShowObject(int showID, int artistID)
        {
            var artistShowData = new ArtistShowData();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowID == showID);
                artistShowData.ShowID = showID;
                artistShowData.ArtistID = artistID;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
