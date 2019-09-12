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
        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Artists
                               .Where(e => e.UserID == _userID)
                               .Select(
                                   e => new ArtistListItem
                                   {
                                       ArtistName = e.ArtistName,
                                       Location = e.Location
                                   }
                                   );
                return query.ToArray();
                    }

        }
    }


}
