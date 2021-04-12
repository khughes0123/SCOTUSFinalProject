using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Data
{
   public class CaseVote
    {
        [Key]
        public int CaseVoteId { get; set; }
        public string CourtDecision { get; set; }

        [Required]
        [ForeignKey(nameof(Court))]
        public int CourtId { get; set; }
        public virtual CourtMembers Court { get; set; }

        [Required]
        [ForeignKey(nameof(Case))]
        public int CaseId { get; set; }
        public virtual Case Case { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
