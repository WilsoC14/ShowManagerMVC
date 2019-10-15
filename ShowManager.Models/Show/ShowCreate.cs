using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Models
{
    public class ShowCreate
    {
        public string ShowName { get; set; }
        //[ForeignKey("Venue")]
        public int VenueID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfShow { get; set; }


    }
}
