using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Models
{
    public class CaseVoteDetail
    {
        public int CaseVoteId { get; set; }

        public CourtMembersDetail Court
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var casevote = ctx.
                }
            }
        }
    }
}
