using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Data
{
    class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public bool IsHeadliner { get; set; }
        

    }
}
