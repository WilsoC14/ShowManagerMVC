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
        //  private readonly Guid _userID;
        //public ArtistService(Guid userID)
        //{
        //    _userID = userID;
        //}
        public ArtistService()
        {//do not delete, need blank ctor to get list of all artists not associated with user
        }

        //Crud
        public bool CreateArtist(ArtistCreate model)
        {
            var entity = new Artist()
            {
                //   UserID = _userID,
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
                               // don't need userID because any user should be able to view all artists. also need all artists to use dropdown list in "AddArtistToShow"                    //  .Where(e => e.UserID == _userID)
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

                var listOfShows = ShowsPlayedToShowDetail(id);


                var artist = new ArtistDetail
                {
                    ArtistID = entity.ArtistID,
                    ArtistName = entity.ArtistName,
                    Location = entity.Location,
                    ListOfShows = listOfShows,
                };
                artist.ArtistCommunity = GetArtistCommunity(artist);
                return artist;
            };
            // artist.ArtistCommunity = GetArtistCommunity(artist);
        }
    


    public List<ShowDetail> ShowsPlayedToShowDetail(int artistID)
    {
        var showService = new ShowService();
        var listOfShowDetail = new List<ShowDetail>();
        var listOfShowIDs = GetShowIDsArtistHasPlayed(artistID);
        foreach (var item in listOfShowIDs)
        {
            var detail = showService.GetShowByID(item.ShowID);
            listOfShowDetail.Add(detail);
        }
        return listOfShowDetail;

    }



    public List<Show> GetShowIDsArtistHasPlayed(int artistID)
    {
        var asdService = new ArtistShowDataService();
        var showService = new ShowService();
        var listOfShows = new List<Show>();
        var ListOfArtistShowData = asdService.GetArtistShowData();
        foreach (var item in ListOfArtistShowData)
        {
            if (item.ArtistID == artistID)
            {
                var show = new Show()
                {
                    ShowID = item.ShowID,
                    VenueID = item.Show.VenueID
                };

                listOfShows.Add(show);
            }
        }
        return listOfShows;

    }

    public List<ArtistListItem> GetArtistCommunity(ArtistDetail baseArtist) //int id
    {
            var artistCommunity = new List<ArtistListItem>();
        // get artistShowData where artistShowData.ShowID == show.ShowID in artist.ListOfShows
        //var artistCommunity = new List<ArtistListItem>();
        foreach (var show in baseArtist.ListOfShows)
        {
            foreach (var artist in show.ListOfArtist)
            {
                if (artist.ArtistID != baseArtist.ArtistID)
                {
                    var artistListItem = new ArtistListItem()
                    {
                        ArtistID = artist.ArtistID,
                        ArtistName = artist.ArtistName,
                        Location = artist.Location
                    };
                    artistCommunity.Add(artistListItem);
                }
            }
        }
        return artistCommunity;
    }
} 
}



