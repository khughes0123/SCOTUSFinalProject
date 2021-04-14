using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Models
{
    public class CaseListItem
    {
        public int CaseId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        [Display(Name= "Date of SCOTUS Decision")]
        public DateTimeOffset? CaseYear { get; set; }
        [Display(Name = "Date Added")]
        public DateTimeOffset CreatedUTC { get; set; }
        public string HouseControl { get; set; }
        public string SenateControl { get; set; }


    }
}
