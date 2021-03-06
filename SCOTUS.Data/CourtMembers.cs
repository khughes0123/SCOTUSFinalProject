using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Data
{
    public class CourtMembers
    {
        [Key]
        public int CourtId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Chief Justice")]
        public string JusticeOneChiefJustice { get; set; }
        [Required]
        public string JusticeTwo { get; set; }
        [Required]
        public string JusticeThree { get; set; }
        [Required]
        public string JusticeFour { get; set; }
        [Required]
        public string JusticeFive { get; set; }
        public string JusticeSix { get; set; }
        public string JusticeSeven { get; set; }
        public string JusticeEight { get; set; }
        public string JusticeNine { get; set; }
        public string JusticeTen { get; set; }

        public DateTimeOffset ModifiedUTC { get; set; }
    }
}
