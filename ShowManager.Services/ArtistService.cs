using ShowManager.Data;
using ShowManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Services
{
    public class ArtistService
    {
        private readonly Guid _userID;
        public ArtistService(Guid userID)
        {
            _userID = userID;
        }

        //Crud
        public bool CreateArtist(ArtistCreate model)
        {
            var entity = new Artist()
            {
                UserID = _userID,
                ArtistName = model.ArtistName,
                Location = model.Location
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;

            }


        }

        //crUd
        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Single(e => e.ArtistID == model.ArtistID);
                entity.ArtistName = model.ArtistName;
                entity.Location = model.Location;
                return ctx.SaveChanges() == 1;
            }
        }

        //cruD
        
        public bool DeleteArtist(int artistId)  //User Role... don't think _userID is needed
                                                // maybe it is needed so that only that user or admin can delete
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistID == artistId);
                ctx.Artists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //Helper
        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Artists
                               .Where(e => e.UserID == _userID)
                               .Select(
                                   e => new ArtistListItem
                                   {
                                       ArtistID = e.ArtistID,
                                       ArtistName = e.ArtistName,
                                       Location = e.Location
                                   }
                                   );
                return query.ToList();
            }

        }


        //Helper
        public Artist GetArtistByName(string artistName)
        {
            var listOfArtists = GetArtists();
            foreach (var artistListItem in listOfArtists)
            {
                if (artistListItem.ArtistName == artistName)
                {
                    var artist = new Artist
                    {
                        ArtistID = artistListItem.ArtistID,
                    };
                    return artist;
                }
            }
            return null;
        }


        //Helper
        public ArtistDetail GetArtistByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistID == id);
                return  //Having the return above the new note is different from other methods I've seen
                    new ArtistDetail
                    {
                        ArtistID = entity.ArtistID,
                        ArtistName = entity.ArtistName,
                        Location = entity.Location
                       
                    };
            }
        }
    }
}



