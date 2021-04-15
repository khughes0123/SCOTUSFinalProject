using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Models
{
    public class CaseEdit
    {
        public int CaseId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTimeOffset? CaseYear { get; set; }
        public string HouseControl { get; set; }
        public string SenateControl { get; set; }

    }
}
