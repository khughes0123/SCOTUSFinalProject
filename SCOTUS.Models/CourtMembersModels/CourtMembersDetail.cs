using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Models
{
    public class CourtMembersDetail
    {
        
        public int CourtId { get; set; }

        
        [Display(Name = "Chief Justice")]
        public string JusticeOneChiefJustice { get; set; }
        
        public string JusticeTwo { get; set; }
       
        public string JusticeThree { get; set; }
        
        public string JusticeFour { get; set; }
        
        public string JusticeFive { get; set; }
        public string JusticeSix { get; set; }
        public string JusticeSeven { get; set; }
        public string JusticeEight { get; set; }
        public string JusticeNine { get; set; }
        public string JusticeTen { get; set; }
    }
}
