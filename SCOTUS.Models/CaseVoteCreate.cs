using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Models
{
    public class CaseVoteCreate
    {
        public string CourtDecision { get; set; }
        public int CourtId { get; set; }
        public int CaseId { get; set; }
    }
}
