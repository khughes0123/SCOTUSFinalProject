﻿using SCOTUS.Data;
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

        public CaseDetail Case
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
