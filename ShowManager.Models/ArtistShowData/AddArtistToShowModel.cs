using ShowManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models.ArtistShowData
{
    public class AddArtistToShowModel
    {
        
        public int ArtistID { get; set; }
        
        public int ShowID { get; set; }  
        public string ShowName { get; set; }
        public string VenueName { get; set; }



      //  public bool IsHeadLiner { get; set; }
    }
}
