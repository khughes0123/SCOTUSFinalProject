using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Models
{
    public class CaseCreate
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Summary { get; set; }
       // [Required]
        [Display(Name= "Date Of SCOTUS Decision")]
        public DateTimeOffset? CaseYear { get; set; }
        public string HouseControl { get; set; }
        public string SenateControl { get; set; }

    }
}
