using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Data
{
    public class ExecutiveBranch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Display(Name="Current President")]
        public string President { get; set; }
        [Required]
        public string Party { get; set; }
        public DateTime InaugurationDate { get; set; }
    }
}
