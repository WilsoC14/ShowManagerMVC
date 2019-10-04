using ShowManager.Data;
using ShowManager.Models.ArtistShowData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Services
{
    public class ArtistShowDataService
    {
        public ArtistShowDataService() { }



        public AddArtistToShowModel GetAddArtistToShowModel(int showID)
        {
            // takes in a show ID from clicking "add artist" button on detail or list view and an empty model


            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shows.Single(e => e.ShowID == showID);
                return new AddArtistToShowModel()
                {
                    ShowID = entity.ShowID,
                    ShowName = entity.ShowName,
                    VenueName = entity.Venue.VenueName,

                };
            }

        }

        

        public bool AddArtistShowDataToDataTable(AddArtistToShowModel model)
        {
            var entity = new ArtistShowData()
            {
                ArtistID = model.ArtistID,
                //IsHeadLiner = model.IsHeadLiner,
                ShowID = model.ShowID,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ArtistShowDatas.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistShowDataListItem> GetArtistShowData()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ArtistShowDatas.Select(e => new ArtistShowDataListItem
                {
                    ArtistShowDataID = e.ArtistShowDataID,
                    ArtistID = e.ArtistID,
                    Artist = e.Artist,
                    ShowID = e.ShowID,
                    Show = e.Show
                });
                return query.ToList();


            }
        }

        public ArtistShowDataDetail GetAsdByID(int id)
        {
            using (var ctx = new ApplicationDbContext())

            {
                var entity = ctx.ArtistShowDatas.Single(e => e.ShowID == id);
                return new ArtistShowDataDetail
                {
                    ArtistShowDataID = entity.ArtistShowDataID,
                    ArtistID = entity.ArtistID,


                    ShowID = entity.ShowID,


                };


            }
        }

        public bool UpdateArtistShowData(ArtistShowDataEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ArtistShowDatas.Single(e => e.ArtistShowDataID == model.ArtistShowDataID);
                entity.ArtistID = model.ArtistID;

                entity.ShowID = model.ShowID;


                return ctx.SaveChanges() == 1;

            }

        }
        public bool DeleteArtistShowData(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ArtistShowDatas.Single(e => e.ArtistShowDataID == id);
                ctx.ArtistShowDatas.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
