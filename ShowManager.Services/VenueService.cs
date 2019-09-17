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
    }
}
