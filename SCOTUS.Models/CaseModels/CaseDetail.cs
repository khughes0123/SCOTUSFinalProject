using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Models
{
    public class CaseDetail
    {
        public int CaseId { get; set; }

        [Display(Name = "Court Case")]
        public string Title { get; set; }
        
        public string Summary { get; set; }
        
        [Display(Name = "Date of SCOTUS Decision")]
        public DateTimeOffset? CaseYear { get; set; }

        [Display(Name = "Date Added To Database")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Most Recently Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
}
