using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models.ArtistShowData
{
    public class ArtistShowDataEdit
    {
        [Key]
        public int EventID { get; set; }
        // public string EventName { get; set; }
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public Data.Artist Artist { get; set; }
        [ForeignKey("Show")]
        public int ShowID { get; set; }
        [Required]
        public string ShowName { get; set; }
        public Data.Show Show { get; set; }
    }
}
