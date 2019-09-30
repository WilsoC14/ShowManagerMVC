using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models.ArtistShowData
{
    public class ArtistShowDataListItem
    {
        public int ArtistShowDataID { get; set; }
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public Data.Artist Artist { get; set; }
        [ForeignKey("Show")]
        public int ShowID { get; set; }
        public string ShowName { get; set; }
        public Data.Show Show { get; set; }
        public bool IsHeadLiner { get; set; }
    }

}
