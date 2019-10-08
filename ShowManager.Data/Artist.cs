using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
   public class Artist
    {
        public Guid UserID { get; set; }
        [Key]
        public int ArtistID { get; set; }
        [Required]
        public string ArtistName { get; set; }
        
        public bool IsHeadliner { get; set; }
        [Required]
        public string Location { get; set; }

        //public virtual ICollection<ArtistShowData> ArtistCommunity { get; set; }
        

    }
}
