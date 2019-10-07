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
        //  private readonly Guid _userID;
        //public ShowService(Guid userID)
        //{
        //    _userID = userID;
        //}
        public ShowService()
        { }

        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var artists = new List<Artist>();
                var query = ctx.Shows.Select(e => new ShowListItem
                {
                    ShowID = e.ShowID,
                    ShowName = e.ShowName,
                    Venue = e.Venue,
                    VenueID = e.VenueID,
                    VenueName = e.Venue.VenueName,
                    VenueType = e.Venue.VenueType,
                    Location = e.Venue.Location,
                    ListOfArtist = artists

                });
                return query.ToList();
            }
        }

        public ShowDetail GetShowByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shows.Single(e => e.ShowID == id);
                var artists = new List<Artist>();
                foreach (var artistShowData in entity.ArtistShowData)
                {
                    artists.Add(artistShowData.Artist);
                }
                return new ShowDetail
                {
                    ShowID = entity.ShowID,
                    ShowName = entity.ShowName,
                    VenueID = entity.VenueID,
                    Venue = entity.Venue,
                    VenueName = entity.Venue.VenueName,
                    VenueType = entity.Venue.VenueType,
                    Location = entity.Venue.Location,
                    ListOfArtist = artists
                };
            }
        }
        public bool CreateShow(ShowCreate model)
        {
            var entity = new Show()
            {
                ShowName = model.ShowName,
                VenueID = model.VenueID,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public bool UpdateShow(ShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shows.Single(e => e.ShowID == model.ShowID);

                entity.ShowName = model.ShowName;
                //need if statement to query database and see if a Show with that Name Exists. Drop Down Window won't work because you're changing the name of a show to one that doesn't exist.
                entity.VenueID = model.VenueID;
                // need code for adding an Artist through ArtistShowData

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
