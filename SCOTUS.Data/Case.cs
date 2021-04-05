using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Data
{
    public class Case
    {
        [Key]
        public int CaseId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Court Case")]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        [Display(Name = "Date of SCOTUS Decision")]
        public DateTime CaseYear { get; set; }
        public string HouseControl { get; set; }
        public string SenateControl { get; set; }
        public int ExecutiveBranchId { get; set; }
        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }

        [Required]
        [ForeignKey(nameof(ExecutiveBranch))]
        public int BranchId { get; set; }
        public virtual ExecutiveBranch ExecutiveBranch { get; set; }
    }
}
