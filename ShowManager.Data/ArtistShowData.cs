using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
    public class ArtistShowData
    {   [Key]
        public int ArtistShowDataID { get; set; }
        
        [Required]
        [ForeignKey("Show")]
        public int ShowID { get; set; }
        public virtual Show Show { get; set; }


        [Required]
        [ForeignKey("Artist")]  
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }


      //  public bool IsHeadLiner { get; set; }
    }
}
