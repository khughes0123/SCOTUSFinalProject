using SCOTUS.Data;
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

        public string CourtDecision { get; set; }
        public string Summary { get; set; }

        public string JusticeOneChiefJustice { get; set; }
        public string JusticeTwo { get; set; }
        public string JusticeThree { get; set; }
        public string JusticeFour { get; set; }
        public string JusticeFive { get; set; }
        public string JusticeSix { get; set; }
        public string JusticeSeven { get; set; }
        public string JusticeEight { get; set; }
        public string JusticeNine { get; set; }
        public string JusticeTen { get; set; }
        public int CourtId { get; set; }
        public int CaseId { get; set; }

        public virtual CourtMembersDetail Court
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var casevote = ctx.CaseVotes.Single(v => v.CaseVoteId == CaseVoteId);
                    var court = ctx.CourtMembers.Single(m => m.CourtId == casevote.CourtId);

                    return new CourtMembersDetail()
                    {
                        JusticeOneChiefJustice = court.JusticeOneChiefJustice,
                        JusticeTwo = court.JusticeTwo,
                        JusticeThree = court.JusticeThree,
                        JusticeFour = court.JusticeFour,
                        JusticeFive = court.JusticeFive,
                        JusticeSix = court.JusticeSix,
                        JusticeSeven = court.JusticeSeven,
                        JusticeEight = court.JusticeEight,
                        JusticeNine = court.JusticeNine,
                        JusticeTen = court.JusticeTen
                    };
                }
            }
        }

        public virtual CaseDetail Case
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var casevote = ctx.CaseVotes.Single(v => v.CaseVoteId == CaseVoteId);
                    var scotuscase = ctx.Cases.Single(c => c.CaseId == casevote.CaseId);

                    return new CaseDetail()
                    {
                        Title = scotuscase.Title,
                        Summary = scotuscase.Summary,
                        CaseYear = scotuscase.CaseYear

                    };
                }
            }
        }
    }
}
