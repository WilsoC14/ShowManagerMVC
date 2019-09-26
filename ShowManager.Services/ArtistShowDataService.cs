using ShowManager.Data;
using ShowManager.Models.ArtistShowData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Services
{
    class ArtistShowDataService
    {
        public bool CreateArtistShowData(ArtistShowDataCreate model)
        {
            var entity = new ArtistShowData()
            {
                ArtistID = model.ArtistID,
                ArtistName = model.ArtistName,
                ShowID = model.ShowID,
                ShowName = model.ShowName
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
                    EventID = e.EventID,
                    ArtistID = e.ArtistID,
                    ArtistName = e.ArtistName,
                    Artist = e.Artist,
                    ShowID = e.ShowID,
                    ShowName = e.ShowName,
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
                    EventID = entity.EventID,
                    ArtistID = entity.ArtistID,
                    ArtistName = entity.ArtistName,
                    Artist = entity.Artist,
                    ShowID = entity.ShowID,
                    ShowName = entity.ShowName,
                    Show = entity.Show
                };


            }
        }

        public bool UpdateArtistShowData (ArtistShowDataEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ArtistShowDatas.Single(e => e.EventID == model.EventID);
                entity.ArtistID = model.ArtistID;
                entity.ArtistName = model.ArtistName;
                entity.Artist = model.Artist;
                entity.ShowID = model.ShowID;
                entity.ShowName = model.ShowName;
                entity.Show = model.Show;
                return ctx.SaveChanges() == 1;

            }

        }
        public bool DeleteArtistShowData (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ArtistShowDatas.Single(e => e.EventID == id);
                ctx.ArtistShowDatas.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
